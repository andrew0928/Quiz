using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz.StreamAnalysis
{
    public class Engine
    {
        public readonly TimeSpan Period = TimeSpan.FromSeconds(10.0);

        public static Engine Create()
        {
            return new Engine();
        }




        public void Input(int value)
        {
            Interlocked.Add(ref this._buffer, value);
        }

        public int GetPeriodSum()
        {
            return this._statistic_result + this._buffer;
        }




        

        private readonly int _max_queue_length = 0;

        private Engine()
        {
            this._max_queue_length = (int)(this.Period.TotalMilliseconds / this._interval.TotalMilliseconds);
            this._queue = new Queue<int>(this._max_queue_length);

            Task.Run(() =>
            {
                while (true)
                {
                    Task.Delay(this._interval).Wait();
                    this._statistic_timer_worker();
                }
            });
        }



        private readonly TimeSpan _interval = TimeSpan.FromSeconds(1.0);

        private Queue<int> _queue = null;
        private int _statistic_result = 0;
        private int _buffer = 0;
        private object _sync_root = new object();

        private void _statistic_timer_worker()
        {
            int buffer_value = Interlocked.Exchange(ref this._buffer, 0);
            
            //lock(this._sync_root)
            {
                this._queue.Enqueue(buffer_value);
                this._statistic_result += buffer_value;

                if (this._queue.Count >= this._max_queue_length)
                {
                    int buffer_dequeue_value = this._queue.Dequeue();
                    this._statistic_result -= buffer_dequeue_value;
                }
            }
        }
    }
}

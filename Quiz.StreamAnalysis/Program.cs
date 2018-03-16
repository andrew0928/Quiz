using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.StreamAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine e = Engine.Create();

            
            Task.Run(() =>
            {
                Random rnd = new Random();
                while (true)
                {
                    //Task.Delay(100).Wait();
                    e.Input(rnd.Next(10));
                }
            });


            while (true)
            {
                Task.Delay(300).Wait();
                Console.WriteLine($"update {e.Period.TotalSeconds} sec statistic: {e.GetPeriodSum()}");
            }

        }
    }
}

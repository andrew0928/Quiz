using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Accounts
{


    public class MainAccount : AccountBase
    {
        private long _balance = 0;

        public MainAccount(long initBalance)
        {
            this._balance = initBalance;
        }


        public override long GetBalance()
        {
            return this._balance;
        }

        /// <summary>
        /// 呼叫 .Transfer(value), 代表在該戶頭內轉入 value 的金額。
        /// 轉帳完成後餘額 (balance) 會增加 value。
        /// 
        /// value 可以是負數，若為負數則代表該筆交易是轉出的動作。
        /// </summary>
        /// <param name="value">轉入金額</param>
        /// <returns>轉帳完成後的餘額</returns>
        public override long Transfer(long value)
        {
            if (this._balance + value < 0) throw new BalanceNotEnoughException();


            //
            // TODO: 確保並行的交易是正確的
            //
            throw new NotImplementedException();
        }
    }
}

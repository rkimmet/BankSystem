using System;

namespace BankSystem
{


    public class Transaction
    {
        public DateTime Date;
        public decimal Amount;
        public string info;
        public Transaction(decimal Amount, DateTime Date, string info)
        {
            this.Date = Date;
            this.Amount = Amount;
            this.info = info;
        }
    }
}
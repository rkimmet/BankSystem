using System;
using System.Text;

namespace BankSystem
{
    public abstract class BankAccount
    {
        private static int accountid = 234345487;
        private List<Transaction> Transactions = new List<Transaction>();

        public string number { get; set; }

        public string owner { get; set; }

        public decimal balance
        {
            get
            {
                decimal balance = 0;
                var amounts = from Transaction in Transactions
                              select Transaction.Amount;

                foreach (var amount in amounts)
                {
                    balance += amount;
                }

                return Math.Round(balance, 2);
            }
        }
       
        public BankAccount(string name, decimal initial_deposit)
        {
            owner = name;
            Transactions.Add(new Transaction(initial_deposit, DateTime.Now, "initial deposit"));
            number = accountid.ToString();
            accountid++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string info)
        {
            if (amount < (decimal).01)
            {
                throw new ArgumentException("amount deposited cannot be less than .01");
            }

            var Deposit = new Transaction(amount, date, info);
            Transactions.Add(Deposit);
        }

        public void MakeWithdraw(decimal amount, DateTime date, string info)
        {
            if (amount < (decimal).01)
            {
                throw new ArgumentException("amount withdrawn cannot be less than .01");
            }

            if (amount > balance)
            {   
                var Overdraftfee = new Transaction(-25, DateTime.Now, "Overdraftfee");
                Transactions.Add(Overdraftfee);
            }

            var Withdrawl = new Transaction(-amount, date, info);
            Transactions.Add(Withdrawl);
        }
        
        public List<Transaction> AccountReport()
        {
            return this.Transactions;
        }

    }

}
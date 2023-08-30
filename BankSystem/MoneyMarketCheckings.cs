using System.Text;

namespace BankSystem
{
    public class MoneyMarketChecking : BankAccount
    {
        public decimal interestrate
        { get; }
        public MoneyMarketChecking(string name, decimal amount) : base(name, amount)
        {
            interestrate = (decimal).02;

        }
        public void Calculateinterest()
        {
            decimal interest = Math.Round(Balance * interestrate / 12, 2);
            if (interest >= (decimal).01)
            {
                MakeDeposit(interest, DateTime.Now, "Interest Accrual");
            }
        }

    }
}
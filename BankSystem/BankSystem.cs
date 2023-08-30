using BankSystem.Models;
using System.Security.Principal;

namespace BankSystem
{
    public class BankSystm : IBanksystem
    {
        private  List<BankAccount> bankAccounts { get; set; }
        private static volatile BankSystm bankSystem = null;
        public static BankSystm Instance
        {
            get
            {
                if (bankSystem == null)
                {
                    bankSystem = new BankSystm();
                };
                return bankSystem;
            }
        }
        public BankSystm()
        {
            bankAccounts = new List<BankAccount> {
            new Checking("Jeff Test", 500),
            new MoneyMarketChecking("Casey Smith", 700),
            new SavingsAccount("Kyle Kenseth", 10000),
            new Checking("Tim Scott", 600),
            new MoneyMarketChecking("Elliot Manson", (decimal)43453.21)
            };
        }

        public  BankAccount GetBankAccount(string id)
        {
            var bank = from acc in bankAccounts
                       where acc.number == id
                       select acc;
            var bankaccount = bank.FirstOrDefault();
            return bankaccount;
        }
        public List<Transaction> GetAccountInquiry(BankAccount bankAccount)
        {
            return (bankAccount.AccountReport());
        }

        public  void MakeDeposit(string id, decimal amount, DateTime Date, string note)
        {
            var bankAccount = GetBankAccount(id);
            bankAccount.MakeDeposit(amount, Date, note);
        }

        public void MakeWithdraw(string id, decimal amount, DateTime Date, string note)
        {
            var bankAccount = GetBankAccount(id);
            bankAccount.MakeWithdraw(amount, Date, note);
        }

        public  BankAccount MakeAccount(string accountName, decimal initialdeposit, int accounttype)
        {
            BankAccount account = null;
            while (account == null)
            {
                switch (accounttype)
                {
                    case 1:
                        account = new SavingsAccount(accountName, initialdeposit);
                       this.AddAccount(account);

                        break;
                    case 2:
                        account = new Checking(accountName, initialdeposit);
                        this.AddAccount(account);
                        break;
                    case 3:
                        account = new MoneyMarketChecking(accountName, initialdeposit);
                        this.AddAccount(account);
                        break;
                    default:
                        Console.WriteLine("Enter a valid command type");
                        break;
                }
            }
            return account;
        }

        private  void AddAccount(BankAccount account)
        {
            this.bankAccounts.Add(account);
        }
    } 
}

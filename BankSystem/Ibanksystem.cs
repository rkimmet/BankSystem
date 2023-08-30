namespace BankSystem
{
    public interface IBanksystem
    {


        public void MakeDeposit(string id, decimal amount, DateTime Date, string note);
        public void MakeWithdraw(string id, decimal amount, DateTime Date, string note);
        public BankAccount GetBankAccount(string id);
        public BankAccount MakeAccount(string id, decimal initialdeposit, int accounttype);
        public List<Transaction> GetAccountInquiry(BankAccount bankAccount);
    }
}

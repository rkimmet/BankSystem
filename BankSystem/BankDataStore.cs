namespace BankSystem
{
    public class BankDataStore
    {
        public  List<BankAccount> BankAccounts { get; set; }
        private static volatile BankDataStore BankAccountList = null;
        public static BankDataStore Instance
        {
            get
            {
                if (BankAccountList == null)
                {
                    BankAccountList = new BankDataStore();
                };
                return BankAccountList;
            }
        }
        public BankDataStore()
        {
            BankAccounts = new List<BankAccount>();
        }
    }
}

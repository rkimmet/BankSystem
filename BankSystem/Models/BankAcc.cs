namespace BankSystem.Models
{
    public class BankAccount
    {
        public string? number { get; set; }

        public string owner { get; set; }

        public int type { get; set; }
        public string? accounttype { get; set; }

        public decimal amount { get; set; }

        public decimal? balance { get; set; }
        
        public List<Transaction>? Transactions { get; set; }
    }
}

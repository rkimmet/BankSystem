namespace BankSystem.Models
{
    public class TransactionModel
    {
        public string Id { get; set; }
        public string? Note { get; set; }
        public decimal amount { get; set; }
        public DateTime Date { get; set; }
    }
}

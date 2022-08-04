namespace MicrosftOOCSharpBankEx.Classes
{
    public class Transaction
    {
        public Transaction(decimal amount, DateTime date, string notes)
        {
            Amount = amount;
            Date = date;
            Notes = notes;
        }

        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        
    }
}

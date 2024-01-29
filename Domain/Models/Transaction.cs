namespace Domain.Models
{
    public class Transaction
    {
        public string Id { get; set; }  

        public DateTime TransactionDate { get; set; }

        public int ProductCode { get; set; }

        public int QTY_IN { get; set; }

        public int QTY_OUT { get; set; }

        public decimal Amount { get; set; } = 0;

        public string? Remarks { get; set; }  


    }
}

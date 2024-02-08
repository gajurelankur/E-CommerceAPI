namespace Domain.Models
{
    public class Transaction
    {
        public string Id { get; set; }  

        public DateTime transaction_date { get; set; }

        public int PRODUCTCODE { get; set; }

        public int QTY_IN { get; set; }

        public int QTY_OUT { get; set; }

        public decimal amount { get; set; } = 0;

        public string? Remarks { get; set; }  

        public string? prefix { get; set; }


    }
}

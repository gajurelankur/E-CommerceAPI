namespace Domain.Models
{
    public class Products
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public string Unit { get; set; }

        public decimal Price { get; set; } = 0;


    }
}

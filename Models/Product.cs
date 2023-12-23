namespace DotNetCoreDominationBootcampDay2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Category Category { get; set; }

    }
}

namespace Domain
{
    public class Company
    {
        public Guid id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public ICollection<Product> Products { get; set; } = default!;

    }
}
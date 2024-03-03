namespace eShop.Areas.Admin.Data.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}

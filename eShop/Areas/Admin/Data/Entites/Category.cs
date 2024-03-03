namespace eShop.Areas.Admin.Data.Entites
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new List<Product>();

    }
}

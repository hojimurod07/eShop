namespace eShop.Areas.Admin.Data.Entites
{
    public class Order : BaseEntity
    {
        public int Amount { get; set; }
        public double TotalPrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();

        public int BuscetId { get; set; }
        public Buscet Buscet { get; set; } = new Buscet();

    }
}

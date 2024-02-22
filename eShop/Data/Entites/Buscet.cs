namespace eShop.Data.Entites
{
    public class Buscet : BaseEntity
    {
        public DateTime Time { get; set; }
        public double TotalPrice { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = new User();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}

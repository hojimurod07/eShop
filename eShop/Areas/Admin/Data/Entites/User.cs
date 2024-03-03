namespace eShop.Areas.Admin.Data.Entites
{
    public class User : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;

        public List<Buscet> Buscets { get; set; } = new List<Buscet>();
    }
}

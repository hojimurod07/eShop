namespace eShop.Areas.Admin.Data.interfaces
{
    public interface IUnitOfWork
    {
        IBuscetInterface Buscets { get; }
        ICategoryInterface Categories { get; }
        IOrderInterface Orders { get; }
        IProductInterface Products { get; }
        IUserInterface Users { get; }
    }
}

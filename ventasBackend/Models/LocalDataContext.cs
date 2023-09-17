namespace ventasBackend.Models
{
    using ventas.Domain.Models;
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<ventas.Common.Models.Product> Products { get; set; }
    }
}
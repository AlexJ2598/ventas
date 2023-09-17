namespace ventas.Domain.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") 
        { 

        }

        public System.Data.Entity.DbSet<ventas.Common.Models.Product> Products { get; set; }
    }
}

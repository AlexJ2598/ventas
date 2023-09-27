namespace ventas.Domain.Models
{
    using Common.Models;
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") 
        { 

        }

        public DbSet<Product> Products { get; set; } //Hay un modelo en Commonm que se llama Products. Al crear el controlador se genera.Mapea la clase product con Entity.
    }
}

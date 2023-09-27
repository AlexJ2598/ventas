namespace ventasBackend.Models
{
    using System.Web;
    using ventas.Common.Models;
    public class ProductView : Product
    {
        public HttpPostedFileBase ImageFile { get; set; } //Para cargar el archivo.
    }
}
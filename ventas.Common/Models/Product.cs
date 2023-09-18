namespace ventas.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Product
    {
        [Key]  //Para referirnos a ProductID como llave primaria
        public int ProductID { get; set; }
        [Required]
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime PublishOn { get; set; }

        //Para mostrar la lista de productos.
        public override string ToString()
        {
            return this.Description;
        }
    }
}

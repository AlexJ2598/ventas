namespace ventas.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Product
    {
        [Key]  //Para referirnos a ProductID como llave primaria
        public int ProductID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
        [Display(Name ="Image")]
        public string ImagePath { get; set; }
        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]
        public Decimal Price { get; set; }
        [Display(Name ="Is Available")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Publish On")] //Esta anotacion es para lo que queramos que el usuario lo vea en el front
        [DataType(DataType.Date)]
        public DateTime PublishOn { get; set; }

        //Para mostrar la lista de productos.
        public override string ToString()
        {
            return this.Description;
        }

        //Usar este comando para habilitar las migraciones de la base de datos:
        //Enable-Migrations -ContextTypeName StoreContext -EnableAutomaticMigrations –Force
        //Desde la consola: Herramientas/Administrador de paquetes nuget/Consola. Verificar que sea solo en el backend en la
        //pestaña proyecto determinado.
        //Editar StoreContext. Cambiarlo por LocalDataContext: Enable-Migrations -ContextTypeName LocalDataContext -EnableAutomaticMigrations –Force
        //Esto nos crea una carpeta en el proyecto con nombre Migrations y una clase Configuratios.cs
        //No olvidar borrar tabla products.

    }
}

namespace ventas.ViewModels
{
    public class MainViewModel
    {
        //Esta nos sirve para controlar a las demás ViewModels
        public ProductsViewModel Products { get; set; }
        public MainViewModel()
        {
            this.Products = new ProductsViewModel(); //Instanciamos
        }
    }
}

namespace ventas.Infrastructure
{
    using ventas.ViewModels;
    public class InstanceLocator
    {
        //Esto es para instanciar la MainViewModel
        public MainViewModel Main { get; set; } //Este es el objeto principal
        public InstanceLocator()
        {
            this.Main = new MainViewModel(); //Esta es la misma para todos los proyectos
        }
    }
}

namespace ventas.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }
        //Cada llave de lo que agregamos a los Recursos la vamos a poner.
        public static string Accept
        {
            get { return Resource.Accept; }
        }
        public static string Error 
        { 
            get { return Resource.Error; } 
        }
        public static string NoInternet
        {
            get { return Resource.NoInternet; }
        }
        public static string Products
        {
            get { return Resource.Products; }
        }
        public static string TurnOnInternet
        {
            get { return Resource.TurnOnInternet; }
        }
    }
}

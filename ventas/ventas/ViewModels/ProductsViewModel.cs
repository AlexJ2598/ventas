namespace ventas.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using ventas.Common.Models;
    using ventas.Services;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products 
        {
            get { return this.products; }
            set {this.SetValue(ref this.products, value); } 
        }
        //Cargamos la lista de prodcutos
        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts(); //Metodo para construir los productos.
        }

        private async void LoadProducts()
        {
            var response = await this.apiService.GetList<Product>("https://ventasapi20230917000719.azurewebsites.net", "/api", "/Products"); //Consume la url base, el prefijo y controlador
            if(!response.isSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }
            var list = (List<Product>)response.Result; //Casteamos.
            this.Products = new ObservableCollection<Product>(list);
        }
    }
}

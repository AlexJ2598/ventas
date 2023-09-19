namespace ventas.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using ventas.Common.Models;
    using ventas.Services;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private bool isRefreshing;

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products 
        {
            get { return this.products; }
            set {this.SetValue(ref this.products, value); } 
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }
        //Cargamos la lista de prodcutos
        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts(); //Metodo para construir los productos.
        }

        private async void LoadProducts()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if (!connection.isSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
                return;
            }
            var url = Application.Current.Resources["UrlAPI"].ToString(); //Consumimos el recuros url creado en APP.xaml. Necesita tiempo
            var response = await this.apiService.GetList<Product>(url, "/api", "/Products"); //Consume la url base, el prefijo y controlador
            if(!response.isSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }
            var list = (List<Product>)response.Result; //Casteamos.
            this.Products = new ObservableCollection<Product>(list);
            this.IsRefreshing = false;
        }

        public ICommand RefreshCommand //Es una propiedad solo de lecutura
        { 
            get
            {
                return new RelayCommand(LoadProducts); //Va a volver a llamar al metodo load para refrescar los productos. GalaSoft.MvvmLight.Command
            }
        }
    }
}

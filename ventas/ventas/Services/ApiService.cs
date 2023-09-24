namespace ventas.Services
{
    using Newtonsoft.Json;
    using Plugin.Connectivity;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using ventas.Common.Models;
    using ventas.Helpers;

    public class ApiService
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected) //    using Plugin.Connectivity; para verificar la conexion.
            {
                //Este metodo es para identifcar que el telefono tenga conexionn a internet. Que tenga el internet activado.
                return new Response
                {
                    isSuccess = false,
                    Message = Languages.TurnOnInternet, //Languages.InternetSetting
                };
            }
            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
            if (!isReachable)
            {
                //Tiene el wifi o los datos activos. Hacemos un ping para ver si no es problema de su red o se quedo sin datos
                return new Response
                {
                    isSuccess = false,
                    Message = Languages.NoInternet,
                };
            }
            return new Response
            {
                isSuccess = true
            };
        }
        public async Task <Response> GetList<T>(string urlBase, string prefix, string controller)
        {
            try
            {
                var client = new HttpClient(); //Objeto para hacer la comunicacion.
                client.BaseAddress = new Uri(urlBase); //Le cargamos la direccion.
                var url = $"{prefix}{controller}"; 
                var response = await client.GetAsync(url); 
                var answer = await response.Content.ReadAsStringAsync();
                if(!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        isSuccess = false,
                        Message = answer
                    };
                }
                //Deserealizar es convertir de string a objetos. Serealizar es convertir un objeto a string. Libreria newtoon nos sirve para estas operaciones.
                var list = JsonConvert.DeserializeObject<List<T>>(answer); //Convertimos el string en un objeto
                return new Response
                {
                    isSuccess = true,
                    Result = list, 
                };


            }catch(Exception ex)
            {
                return new Response
                {
                    isSuccess = false,
                    Message = ex.Message,
                    
                };
            }
        }
    }
}

namespace ventas.Services
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using ventas.Common.Models;
    public class ApiService
    {
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

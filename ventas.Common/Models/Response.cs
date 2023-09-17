namespace ventas.Common.Models
{
    public class Response
    {
        private object result;

        public bool isSuccess { get; set; } //Exitosa o no la comunicacion.
        public string Message { get; set; }
        //blic object Result { get; set; } //Object porque es generico
        public object Result { get => result; set => result = value; } //Object porque es generico
    }
}

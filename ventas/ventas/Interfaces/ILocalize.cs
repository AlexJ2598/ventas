namespace ventas.Interfaces
{
    using System.Globalization;
    public interface ILocalize
    { 
        //Diferencia entre una interfaz y una clase? En una interfaz yo no defino los metodos.Los encabezados los dejamos y esos los
        //vamos a implementar en otra plataforma.
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);

        //La interfaz es diferente como vamos a obtener la cultere en difierente plataformas, se va a implementar de manera especifica en 
        //las plataformas seleccionadas
    }
}

//Complizacion. Se cambia solo el nombre del proyecto, en este caso en ventas. Ver namespace
[assembly: Xamarin.Forms.Dependency(typeof(ventas.iOS.Implementations.Localize))]

namespace ventas.iOS.Implementations
{
    using Foundation;
    using Helpers;
    using Interfaces;
    using System.Globalization;
    using System.Threading;
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = iOSToDotnetLanguage(pref);
            }
            System.Globalization.CultureInfo ci = null;
            try
            {
                ci = new System.Globalization.CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    ci = new System.Globalization.CultureInfo(fallback);
                }
                catch (CultureNotFoundException e2)
                {
                    ci = new System.Globalization.CultureInfo("en");
                }
            }
            return ci;
        }
        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
        string iOSToDotnetLanguage(string iOSLanguage)
        {
            var netLanguage = iOSLanguage;
            switch (iOSLanguage)
            {
                case "ms-MY": //Malasia
                case "ms-SG":
                    netLanguage = "ms"; //Singapore
                    break;
                case "gsw-CH":
                    netLanguage = "de-CH"; //Swiss German not supported. Close supp
                    break;
                    //More case if is necessary
            }
            return netLanguage;
        }
        string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            var netLanguage = platCulture.LanguageCode;
            switch (platCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT"; //fallback Portuguse
                    break;
                case "gsw":
                    netLanguage = "de-CH"; //Equivalent to German
                    break;
                //Add more only to need necesary
            }
            return netLanguage;
        }
    }
}
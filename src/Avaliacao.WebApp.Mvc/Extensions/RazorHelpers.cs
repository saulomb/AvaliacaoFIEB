using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Avaliacao.WebApp.Mvc.Extensions
{
    public static class RazorHelpers
    {

        private static string FormatoMoeda(decimal valor)
        {
            return string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", valor);
        }


        public static string FormatoMoeda(this RazorPage page, decimal valor)
        {
            return string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", valor);
        }   

    }
}
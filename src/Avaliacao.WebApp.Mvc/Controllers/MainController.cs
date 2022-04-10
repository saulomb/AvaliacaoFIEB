using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Avaliacao.WebApp.Mvc.Controllers
{
    public class MainController : Controller
    {
        protected void AdicionarErroValidacao(string mensagem)
        {
            ModelState.AddModelError(string.Empty, mensagem);
        }

        protected bool OperacaoValida()
        {
            return ModelState.ErrorCount == 0;
        }
    }
}

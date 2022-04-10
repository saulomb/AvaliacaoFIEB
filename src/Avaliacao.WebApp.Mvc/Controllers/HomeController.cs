using Avaliacao.Application.Services;
using Avaliacao.WebApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliacao.WebApp.Mvc.Controllers
{
    public class HomeController : MainController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFuncionarioAppService _funcionarioAppService;

        public HomeController(ILogger<HomeController> logger,
                             IFuncionarioAppService funcionarioAppService)
        {
            _logger = logger;
            _funcionarioAppService = funcionarioAppService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var funcionarios = await _funcionarioAppService.ObterTodos();
            return View(funcionarios);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}

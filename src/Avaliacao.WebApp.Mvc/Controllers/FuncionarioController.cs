using Avaliacao.Application.Services;
using Avaliacao.Application.ViewModels;
using Avaliacao.WebApp.Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliacao.WebApp.Mvc.Controllers
{
    public class FuncionarioController : MainController
    {
        private readonly IFuncionarioAppService _funcionarioAppService;
        private readonly IIbgeService _ibgeService;

        public FuncionarioController(
             IFuncionarioAppService funcionarioAppService,
             IIbgeService ibgeService
             )
        {
            _funcionarioAppService = funcionarioAppService;
            _ibgeService = ibgeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var funcionarios = await _funcionarioAppService.ObterTodos();
            return View(funcionarios);
        }
        
        [HttpGet]
        public async Task<IActionResult> Detalhe(int Id)
        {
            var funcionarioDetalhe = await _funcionarioAppService.ObterPorId(Id);
            return View(funcionarioDetalhe);
        }

        [HttpGet]
        public async Task<IActionResult> Adicionar()
        {
            
            return View(await PopularDados(new FuncionarioViewModel()));
        }

       [HttpPost]
        public async Task<IActionResult> Adicionar(FuncionarioViewModel funcionario)
        {
            if (!ModelState.IsValid) return View(await PopularDados(funcionario));

            await _funcionarioAppService.AdicionarFuncionario(funcionario);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(FuncionarioViewModel funcionario)
        {
            if (!ModelState.IsValid) return View(await PopularDados(funcionario));

            await _funcionarioAppService.AlterarFuncionario(funcionario);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Atualizar(int Id)
        {
            var funcionario = await _funcionarioAppService.ObterPorId(Id);

            return View(await PopularDados(funcionario));
        }

        [HttpGet]
        public async Task<IActionResult> Remover(int Id)
        {
            await _funcionarioAppService.RemoverFuncionario(Id);

            return RedirectToAction("Index");
        }
    

        [HttpGet]
        public async Task<IActionResult> DefinirEscala(int Id)
        {
            var funcionario = await _funcionarioAppService.ObterPorId(Id);

            if (funcionario.TotalEscalaSemanal > 40)
                AdicionarErroValidacao("Carga Horária não pode ser superior a 40hs");
            if (funcionario.TotalEscalaSemanal < 20)
                AdicionarErroValidacao("Carga Horária inferior a 20hs");

            return View(funcionario);
        }

        [HttpGet]
        public async Task<IActionResult> AdicionarEscala(int Id)
        {
            return View(await Task.FromResult(new EscalaViewModel{ FuncionarioId = Id} ));
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEscala( EscalaViewModel escala)
        {
            if (!ModelState.IsValid) return View(escala);

            if (await JaTemEscalaNaSemana(escala)) return View(escala);

            await _funcionarioAppService.AdicionarEscala(escala);

            return RedirectToAction("DefinirEscala", new { Id = escala.FuncionarioId});
        }

        [HttpGet]
        public async Task<IActionResult> VisualizarEscala(int Id)
        {
            var escala = await _funcionarioAppService.ObterEscalaPorId(Id);
            return View(escala);
        }

        [HttpPost]
        public async Task<IActionResult> RemoverEscala(EscalaViewModel escala)
        {
            
            await _funcionarioAppService.RemoverEscala(escala);

            return RedirectToAction("DefinirEscala", new { Id = escala.FuncionarioId });
        }

        private async Task<FuncionarioViewModel> PopularDados(FuncionarioViewModel funcionario)
        {
            funcionario.Cargos = await _funcionarioAppService.ObterCargos();
            var estados = await _ibgeService.ObterEstados();
            funcionario.Estados = estados.OrderBy(e => e.Sigla);
            funcionario.Estado = "BA";
            funcionario.CidadesPorEstado = await _ibgeService.ObterCidadesPorEstado(funcionario.Estado);



            return funcionario;
        }

        private async Task<bool> JaTemEscalaNaSemana(EscalaViewModel escala)
        {
            var funcionatio = await _funcionarioAppService.ObterPorId(escala.FuncionarioId);

            var temEscala = funcionatio.EscalaSemanal.Any(e => e.DiaDaSemana == escala.DiaDaSemana);

            if (temEscala)
                AdicionarErroValidacao("Já existe escala cadastrada desse dia");
            return funcionatio.EscalaSemanal.Any(e => e.DiaDaSemana == escala.DiaDaSemana);

        }
    }
}

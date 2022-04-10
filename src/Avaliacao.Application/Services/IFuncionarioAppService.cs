using Avaliacao.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Application.Services
{


    public interface IFuncionarioAppService : IDisposable
    {
        Task<FuncionarioViewModel> ObterPorId(int Id);
        Task<IEnumerable<FuncionarioViewModel>> ObterTodos();
        Task<IEnumerable<CargoViewModel>> ObterCargos();
        
        Task AdicionarFuncionario(FuncionarioViewModel funcionario);
        
        Task AlterarFuncionario(FuncionarioViewModel funcionario);

        Task RemoverFuncionario(int funcionarioId);

        Task AdicionarEscala(EscalaViewModel escalaViewModel);
        Task AtualizarEscala(EscalaViewModel escalaViewModel);
        Task RemoverEscala(EscalaViewModel escalaViewModel);

        Task<EscalaViewModel> ObterEscalaPorId(int Id);

    }
}

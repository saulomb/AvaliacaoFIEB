using Avaliacao.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avaliacao.Domain.RH.Repository
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {

        Task<IEnumerable<Funcionario>> ObterTodos();
        Task<Funcionario> ObterPorId(int id);
        void Adicionar(Funcionario funcionario);
        void Atualizar(Funcionario funcionario);
        void Remover(Funcionario funcionario);

    }
}

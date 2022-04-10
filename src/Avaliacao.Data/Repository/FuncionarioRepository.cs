using Avaliacao.Core.Data;
using Avaliacao.Domain.RH;
using Avaliacao.Domain.RH.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Data.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private readonly AvaliacaoContext _context;

        public FuncionarioRepository(AvaliacaoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public DbConnection ObterConexao() => _context.Database.GetDbConnection();

        public async Task<Funcionario> ObterPorId(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) return null;

            await _context.Entry(funcionario)
                    .Collection(i => i.EscalaSemanal).LoadAsync();


            await _context.Entry(funcionario)
                    .Reference(i => i.Cargo).LoadAsync();


       

            return funcionario;
        }

        public async Task<IEnumerable<Funcionario>> ObterTodos()
        {
            return await _context.Funcionarios.AsNoTracking().ToListAsync();
        }

        public void Adicionar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
        }

        public void Atualizar(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
        }

        public void Remover(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
        }


        //public async Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId)
        //{
        //    return await _context.Pedidos
        //        .Include(p => p.PedidoItems)
        //        .AsNoTracking()
        //        .Where(p => p.ClienteId == clienteId)
        //        .ToListAsync();
        //}

        //public void Adicionar(Pedido pedido)
        //{
        //    _context.Pedidos.Add(pedido);
        //}

        //public void Atualizar(Pedido pedido)
        //{
        //    _context.Pedidos.Update(pedido);
        //}


        //public async Task<PedidoItem> ObterItemPorId(Guid id)
        //{
        //    return await _context.PedidoItems.FindAsync(id);
        //}

        //public async Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
        //{
        //    return await _context.PedidoItems
        //        .FirstOrDefaultAsync(p => p.ProdutoId == produtoId && p.PedidoId == pedidoId);
        //}

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}

using Avaliacao.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avaliacao.WebApp.Mvc.Services
{
    public interface IIbgeService
    {
        Task<IEnumerable<EstadoViewModel>> ObterEstados();
        Task<IEnumerable<CidadeViewModel>> ObterCidadesPorEstado(string estado);

    }
}

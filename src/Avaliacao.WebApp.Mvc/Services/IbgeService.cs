using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Avaliacao.Application.ViewModels;
using Avaliacao.WebApp.Mvc.Extensions;
using Avaliacao.WebApp.Mvc.Services;
using Microsoft.Extensions.Options;


namespace Avaliacao.WebApp.MVC.Services
{
    public class IbgeService : Service, IIbgeService
    {
        private readonly HttpClient _httpClient;

        public IbgeService(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.IbgeApiUrl);
            
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EstadoViewModel>> ObterEstados()
        {
            var response = await _httpClient.GetAsync("/api/v1/localidades/estados");

             return await DeserializarObjetoResponse<IEnumerable<EstadoViewModel>>(response);
        }

        public async Task<IEnumerable<CidadeViewModel>> ObterCidadesPorEstado(string estado)
        {
            var response = await _httpClient.GetAsync($"/api/v1/localidades/estados/{estado}/municipios");

            return await DeserializarObjetoResponse<IEnumerable<CidadeViewModel>>(response);
        }


    }
}
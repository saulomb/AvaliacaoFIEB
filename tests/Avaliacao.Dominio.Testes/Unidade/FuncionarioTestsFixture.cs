using Avaliacao.Domain.RH;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Avaliacao.Dominio.Testes.Unidade
{

    [CollectionDefinition(nameof(FuncionarioCollection))]
    public class FuncionarioCollection : ICollectionFixture<FuncionarioTestsFixture>
    { }
    
    
    public class FuncionarioTestsFixture: IDisposable
    {

        public const int HORA_INICIAL_PADRAO = 8;

 

        public Funcionario GeraFuncionarioValido()
        {
            var funcionario = new Funcionario(
                "Saulo Mendonça",
                "121212121",
                "saulomb@gmail.com",
                "9999-6666",
                1,
                15000);
            return funcionario;
        }


        public Escala GerarEscala(DiasDaSemana dia, int cargaHoraia, int tempoDescanso = 0)
        {

            var horaFinal = HORA_INICIAL_PADRAO + cargaHoraia + tempoDescanso;
            var escala = new Escala(dia,
                                new TimeSpan(8, 0, 0),
                                new TimeSpan(horaFinal, 0, 0),
                                tempoDescanso);

            return escala;
        }


        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}

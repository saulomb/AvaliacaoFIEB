using Avaliacao.Core.DomainObjects;
using Avaliacao.Domain.RH;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Avaliacao.Dominio.Testes.Unidade
{
   [Collection(nameof(FuncionarioCollection))]
    public class FuncionarioAssertingExceptionsTests
    {
       
        public const int HORA_INICIAL_PADRAO = 8;

        private readonly FuncionarioTestsFixture _funcionarioEscalaTestsFixture;

        public FuncionarioAssertingExceptionsTests(FuncionarioTestsFixture funcionarioEscalaTestsFixture)
        {
            _funcionarioEscalaTestsFixture = funcionarioEscalaTestsFixture;
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
        
        
        [Fact]
        public void Escala_VerificaSeExisteParaODia_DeveRetornaErroQueJaExiste()
        {
            //Arrange

            var funcionario = _funcionarioEscalaTestsFixture.GeraFuncionarioValido();

            var escalaDaSegunda1 = _funcionarioEscalaTestsFixture.GerarEscala(DiasDaSemana.Segunda, 8, 2);
            var escalaDaSegunda2 = _funcionarioEscalaTestsFixture.GerarEscala(DiasDaSemana.Segunda, 7, 1);


            funcionario.AdiconarEscala(escalaDaSegunda1);


            //Act e Assert
            Assert.Throws<DomainException>(() => funcionario.AdiconarEscala(escalaDaSegunda2));

        }


        [Fact]
        public void Escala_VerificaSeTotalHorasDasEscalasEhMaiorQue40_DeveRetornaErroQueNaoDeveSerMaiorQue40()
        {
            //Arrange
            var escalaSegunda = _funcionarioEscalaTestsFixture.GerarEscala(DiasDaSemana.Segunda, 10, 2);
            var escalaTerca = _funcionarioEscalaTestsFixture.GerarEscala(DiasDaSemana.Terca, 9, 2);
            var escalaQuarta = _funcionarioEscalaTestsFixture.GerarEscala(DiasDaSemana.Quarta, 11, 2);
            var escalaQuinta = _funcionarioEscalaTestsFixture.GerarEscala(DiasDaSemana.Quinta, 13, 2);

            var escalaSexta = _funcionarioEscalaTestsFixture.GerarEscala(DiasDaSemana.Sexta, 8, 2);

            var funcionario = _funcionarioEscalaTestsFixture.GeraFuncionarioValido();


            funcionario.AdiconarEscala(escalaSegunda);
            funcionario.AdiconarEscala(escalaTerca);
            funcionario.AdiconarEscala(escalaQuarta);
            funcionario.AdiconarEscala(escalaQuinta);
            


            //Act e Assert
            Assert.Throws<DomainException>(() => funcionario.AdiconarEscala(escalaSexta));

        }



    }
}

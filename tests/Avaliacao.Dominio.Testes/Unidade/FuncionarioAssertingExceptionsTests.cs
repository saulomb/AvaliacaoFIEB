using Avaliacao.Core.DomainObjects;
using Avaliacao.Domain.RH;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Avaliacao.Dominio.Testes.Unidade
{
    public class FuncionarioAssertingExceptionsTests
    {
        [Fact]
        public void Escala_VerificaSeExisteParaODia_DeveRetornaErroQueJaExiste()
        {
            //Arrange
            var funcionario = new Funcionario("Saulo Mendonça", "121212121", "saulomb@gmail.com", "9999-6666",1, 15000);
            var escalaDaSegunda1 = new Escala(DiasDaSemana.Segunda, new TimeSpan(8, 0, 0), new TimeSpan(20, 0, 0), 2);
            var escalaDaSegunda2 = new Escala(DiasDaSemana.Segunda, new TimeSpan(7, 0, 0), new TimeSpan(18, 0, 0), 2);

            funcionario.AdiconarEscala(escalaDaSegunda1);


            //Act e Assert
            Assert.Throws<DomainException>(() => funcionario.AdiconarEscala(escalaDaSegunda2));

        }


        [Fact]
        public void Escala_VerificaSeTotalHorasDasEscalasEhMaiorQue40_DeveRetornaErroQueNaoDeveSerMaiorQue40()
        {
            //Arrange
            var funcionario = new Funcionario("Saulo Mendonça", "121212121", "saulomb@gmail.com", "9999-6666", 1, 15000);
            //Total de 10hs
            var escalaDaSegunda = new Escala(DiasDaSemana.Segunda, new TimeSpan(8, 0, 0), new TimeSpan(20, 0, 0), 2);
            //Total de 9hs
            var escalaDaTerca = new Escala(DiasDaSemana.Terca, new TimeSpan(7, 0, 0), new TimeSpan(18, 0, 0), 2);
            //Total de 11hs
            var escalaDaQuarta = new Escala(DiasDaSemana.Quarta, new TimeSpan(7, 0, 0), new TimeSpan(20, 0, 0), 2);
            //Total de 13hs
            var escalaDaQuinta = new Escala(DiasDaSemana.Quinta, new TimeSpan(7, 0, 0), new TimeSpan(22, 0, 0), 2);
            //Total de 8hs
            var escalaDaSexta = new Escala(DiasDaSemana.Sexta, new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0), 2);

            funcionario.AdiconarEscala(escalaDaSegunda);
            funcionario.AdiconarEscala(escalaDaTerca);
            funcionario.AdiconarEscala(escalaDaQuarta);
            funcionario.AdiconarEscala(escalaDaQuinta);
            


            //Act e Assert
            Assert.Throws<DomainException>(() => funcionario.AdiconarEscala(escalaDaSexta));

        }



    }
}

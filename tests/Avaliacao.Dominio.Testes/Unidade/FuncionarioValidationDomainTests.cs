using Avaliacao.Domain.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Avaliacao.Dominio.Testes.Unidade
{



    [Collection(nameof(FuncionarioCollection))]
    public class FuncionarioValidationDomainTests
    {
        private readonly FuncionarioTestsFixture _funcionarioEscalaTestsFixture;

        public FuncionarioValidationDomainTests(FuncionarioTestsFixture funcionarioEscalaTestsFixture)
        {
            _funcionarioEscalaTestsFixture = funcionarioEscalaTestsFixture;
        }



        [Fact(DisplayName = "Verifica se funionário é válido")]
        [Trait("Funcionario", "Funcionario Validação Trait Testes")]
        public void Funcionario_VerificaEhvalido_DeveRetornaValido()
        {
            //Arrange

            var funcionario = _funcionarioEscalaTestsFixture.GeraFuncionarioSemEscalaValido();


            //Act
            var funcionarioValido = funcionario.EhValido();

            //var temErroCPF = funcionario.ValidationResult.Errors.Where(e => e.PropertyName == "Cpf").SingleOrDefault();



            //Assert
            Assert.True(funcionarioValido);
            Assert.Equal(0, funcionario.ValidationResult.Errors.Count);

        }


        [Fact(DisplayName = "Verifica se funionário tem escala abaixo de 20 horas")]
        [Trait("Funcionario", "Funcionario Validação Trait Testes")]
        public void Funcionario_VerificaEscalaEhvalido_DeveRetornaEscalaInValida()
        {
            //Arrange

            var funcionario = _funcionarioEscalaTestsFixture.GeraFuncionarioSemEscalaValido();


            //Act

            funcionario.AdiconarEscala(_funcionarioEscalaTestsFixture
                        .GerarEscala(DiasDaSemana.Segunda, 10, 2));
            var funcionarioValido = funcionario.EhValido();

            
            
            var temErroEscala = funcionario.ValidationResult.Errors
                .Where(e => e.ErrorMessage.Contains("menor que 20 horas")).SingleOrDefault();



            //Assert
            Assert.False(funcionarioValido);
            Assert.NotNull(temErroEscala);

        }



        [Fact(DisplayName = "Verifica se funionário não é válido")]
        [Trait("Funcionario", "Funcionario Validação Trait Testes")]
        public void Funcionario_VerificaEhInvalido_DeveRetornaInvalido()
        {
            //Arrange

            var funcionario = _funcionarioEscalaTestsFixture.GeraFuncionarioSemEscalaInValido();

           
            //Act
            var funcionarioValido = funcionario.EhValido();

            //var temErroCPF = funcionario.ValidationResult.Errors.Where(e => e.PropertyName == "Cpf").SingleOrDefault();



            //Assert
            Assert.False(funcionarioValido);
            Assert.NotEqual(0, funcionario.ValidationResult.Errors.Count);

        }


        [Fact(DisplayName = "Verifica se CPF não é válido")]
        [Trait("Funcionario", "Funcionario Validação Trait Testes")]
        public void Funcionario_VerificaComCpfInvalido_DeveRetornaInvalido()
        {
            //Arrange
            var funcionario = _funcionarioEscalaTestsFixture.GeraFuncionarioSemEscalaInValido();

            //Act
            var funcionarioValido = funcionario.EhValido();
            // var temErroCPF = funcionario.ValidationResult.Errors.Where(e => e.PropertyName == "Cpf" || e.ErrorMessage == "O CPF é inválido!").SingleOrDefault();
            var temErroCPF = funcionario.ValidationResult.Errors.Where(e => e.PropertyName.ToUpper() == "CPF").SingleOrDefault();
            //Assert
            Assert.False(funcionarioValido);
            Assert.NotNull(temErroCPF);

        }



    }
}

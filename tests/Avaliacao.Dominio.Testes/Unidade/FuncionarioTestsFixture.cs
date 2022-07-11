using Avaliacao.Domain.RH;
using Bogus;
using Bogus.DataSets;
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

 

        public Funcionario GeraFuncionarioSemEscalaInValido()
        {
            var funcionario = new Funcionario(
                "Saulo Mendonça",
                "121212121",
                "sau.test.br",
                "4545454559996666",
                0,
                0);
            return funcionario;


        }


        public Funcionario GeraFuncionarioSemEscalaValido()
        {
            //var funcionario = new Funcionario(
            //    "Saulo Mendonça Bezerra",
            //    "79214940568",
            //    "saulomb@gmail.com",
            //    "719999-6666",
            //    1,
            //    9000);
            //return funcionario;

            var genero = new Faker().PickRandom<Name.Gender>();
            var Salario = new Random();

            var funcionario = new Faker<Funcionario>("pt_BR")
                .CustomInstantiator(f => new Funcionario(
                     f.Name.FirstName(genero) + " " + f.Name.LastName(genero),
                      "79214940568",
                       // f.Internet.Email(f.Name.FirstName(genero), f.Name.LastName(genero)),
                       "",
            f.Phone.PhoneNumber("(##)# ####-####"),
                      1,
                     Salario.Next(1220, 49_000)
                    )).RuleFor(c => c.Email, (f, c) =>
                                f.Internet.Email(c.Nome.ToLower()));

            return funcionario;
        }


        public Escala GerarEscala(DiasDaSemana dia, int cargaHoraria, int tempoDescanso = 0)
        {

            var horaFinal = HORA_INICIAL_PADRAO + cargaHoraria + tempoDescanso;
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

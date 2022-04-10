using Avaliacao.Application.Validator;
using Avaliacao.Domain.RH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace Avaliacao.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("CPF")]
        [Cpf]
        public string Cpf { get;  set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        [DisplayName("E-mail")]
        public string Email { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int CargoId { get; set; }
        public IEnumerable<CargoViewModel> Cargos { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Salário")]
        public decimal Salario { get; set; }

        public string SalarioFormatoMoeda { get { return Salario.ToString("C", CultureInfo.CurrentCulture); } }

        [DisplayName("Habilitação")]
        public bool Habilitacao { get;  set; }
        [DisplayName("Categoria da Habilitação")]
        public HabilitacaoCategoria? Categoria { get;  set; }

        //Língua Estrangeira
        [DisplayName("Ingês")]
        public bool Ingles { get; set; }
        [DisplayName("Espanhol")]
        public bool Espanhol { get; set; }
        [DisplayName("Francês")]
        public bool Frances { get; set; }

        //Endereço
        public string Logradouro { get; set; }
        [DisplayName("Número")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public IEnumerable<EstadoViewModel> Estados { get; set; }
        public string Cidade { get; set; }
        public IEnumerable<CidadeViewModel> CidadesPorEstado { get; set; }



        public List<EscalaViewModel> EscalaSemanal { get; set; }
        //public List<HabilitacaoCategoria> ListaCategorias => Enum.GetValues(typeof(HabilitacaoCategoria)).Cast<char>().ToList();

        public decimal TotalEscalaSemanal { get; set; }

        public static FuncionarioViewModel ParaFuncionarioViewModel(Funcionario funcionario)
        {
            var funcionarioViewModel = new FuncionarioViewModel
            {
                Id = funcionario.Id,
                CargoId = funcionario.CargoId,
                Nome = funcionario.Nome,
                Cpf = funcionario.Cpf,
                Email = funcionario.Email,
                Telefone = funcionario.Telefone,
                Habilitacao = funcionario.Habilitacao,
                //Categoria = (char)funcionario.Categoria,
                Categoria = funcionario.Categoria,
                Salario = funcionario.Salario,
                Ingles = funcionario.LinguaEstrangeira.Ingles,
                Espanhol = funcionario.LinguaEstrangeira.Espanhol,
                Frances = funcionario.LinguaEstrangeira.Frances,
                Logradouro = funcionario.Endereco.Logradouro,
                Numero = funcionario.Endereco.Numero,
                Complemento = funcionario.Endereco.Complemento,
                Bairro = funcionario.Endereco.Bairro,
                Cep = funcionario.Endereco.Cep,
                Estado = funcionario.Endereco.Estado,
                Cidade = funcionario.Endereco.Cidade,
                EscalaSemanal = new List<EscalaViewModel>(),
                TotalEscalaSemanal = funcionario.CalcularCargaHorariaSemanal()
            };

            //if (funcionario?.EscalaSemanal != null)
            foreach (var item in funcionario.EscalaSemanal)
               funcionarioViewModel.EscalaSemanal.Add(EscalaViewModel.ParaEscalaViewModel(item));
       

            return funcionarioViewModel;
        }

    }
}

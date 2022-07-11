using Avaliacao.Core.DomainObjects;
using FluentValidation;

namespace Avaliacao.Domain.RH.Validacao
{
    public class FuncionarioValidacao : AbstractValidator<Funcionario>
    {
        public FuncionarioValidacao()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o nome")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

            RuleFor(c => c.Cpf)
                .NotEmpty()
                .Must(Cpf.Validar)
                .WithMessage("O CPF é inválido!");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.CargoId)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o cargo");

            RuleFor(c => c.Salario)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter informado o salário")
                .GreaterThan(0).WithMessage("O Salário tem que ser maior que zero.");
               // .GreaterThan(50_000).WithMessage("O Salário não pode ser maior que R$ 50.000");

            RuleFor(c => c.CalcularCargaHorariaSemanal())
                .LessThanOrEqualTo(40)
                .When(c => c.CalcularCargaHorariaSemanal() > 0)
                .WithMessage("A carga horária semanal não pode ultrapassar 40 horas");


            RuleFor(c => c.CalcularCargaHorariaSemanal())
                .GreaterThanOrEqualTo(20)
                .When(c => c.CalcularCargaHorariaSemanal() > 0)
                .WithMessage("A carga horária semanal não pode ser menor que 20 horas");
                
        }

  
    }
}

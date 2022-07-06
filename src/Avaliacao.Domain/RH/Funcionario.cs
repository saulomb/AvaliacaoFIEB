using Avaliacao.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avaliacao.Domain.RH
{
    public class Funcionario : Entity<int>
    {
        protected Funcionario() 
        {
            LinguaEstrangeira = new LinguaEstrangeira { Ingles = false, Espanhol = false, Frances = false };
            _escalaSemanal = new List<Escala>();

        }

        public Funcionario(string nome, string cpf, string email, string telefone, int cargoId, decimal salario)
        {
            Atualizar(nome, cpf, email, telefone, cargoId, salario);
            LinguaEstrangeira = new LinguaEstrangeira { Ingles = false, Espanhol = false, Frances = false };
            _escalaSemanal = new List<Escala>();
        }
        public void Atualizar(string nome, string cpf, string email, string telefone, int cargoId, decimal salario)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            CargoId = cargoId;
            Salario = salario;
            Habilitacao = false;
            Categoria = null;
        }
        public string Nome { get; private set; }

        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public bool Habilitacao { get; private set; }
        public HabilitacaoCategoria? Categoria { get; private set; }

        public LinguaEstrangeira LinguaEstrangeira { get; private set; }

        public int CargoId { get; private set; }

        public Cargo Cargo { get; private set; }

        public decimal Salario { get; private set; }

        private readonly List<Escala> _escalaSemanal;
        public IReadOnlyCollection<Escala> EscalaSemanal => _escalaSemanal;

        public Endereco Endereco { get; private set; }


        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void AtribuirLinguaEstrageira(LinguaEstrangeira linguaEstrangeira)
        {
            LinguaEstrangeira = linguaEstrangeira;
        }

        public void AtribuirHabilitacao(HabilitacaoCategoria categoria)
        {
            Habilitacao = true;
            Categoria = categoria;
        }

        public void LimparHabilitacao()
        {
            Habilitacao = false;
            Categoria = null;
        }

        public void AdiconarEscala(Escala escala)
        {
            if (EscalaDiaExsitente(escala))
                throw new DomainException("Já existe uma escala atribuida para esse dia da semana!");

            if (CalcularCargaHorariaSemanal() > 40)
                throw new DomainException("Carga Horária não pode ser superior a 40hs");
            

            _escalaSemanal.Add(escala);
        }

        public void RemoverEscala(Escala escala)
        {
            if (!EscalaExsitente(escala)) return;

            _escalaSemanal.Remove(escala);
        }
        public bool EscalaDiaExsitente(Escala escala)
        {
            return _escalaSemanal.Any(p => p.DiaDaSemana == escala.DiaDaSemana);
        }

        private bool EscalaExsitente(Escala escala)
        {
            return _escalaSemanal.Any(p => p.Id == escala.Id);
        }

        public decimal CalcularCargaHorariaSemanal()
        {

            var carhaHorariaSemanal = _escalaSemanal.Count > 0 ? _escalaSemanal.Sum(p => p.CalculaCargaHoraria()) : 0;
           
            return carhaHorariaSemanal;
        }
    }
}

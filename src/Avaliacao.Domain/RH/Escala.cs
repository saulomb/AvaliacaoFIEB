using Avaliacao.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avaliacao.Domain.RH
{
    public class Escala: Entity<int>
    {
        
        public Escala(int funcionarioId, DiasDaSemana diaDaSemana, TimeSpan horaInicio, TimeSpan horaTermino, int tempoDeDescanco)
            : this(diaDaSemana, horaInicio, horaTermino, tempoDeDescanco)
        {


            FuncionarioId = funcionarioId;

            //if (horaInicio >= horaTermino)
            //    throw new DomainException("Hora de início não pode ser maior ou igual a hora de termino!");

            //if (tempoDeDescanco < 0)
            //    throw new DomainException("Tempo de descanso não poder ser menor que zero!");


            //FuncionarioId = funcionarioId;
            //DiaDaSemana = diaDaSemana;
            //HoraInicio = horaInicio;
            //HoraTermino = horaTermino;
            //TempoDescanso = tempoDeDescanco;

            //if (CalculaCargaHoraria() <= 0)
            //    throw new DomainException("Tempo de descanso não poder ser maior ou igual que a carga horária!");


        }

        public Escala( DiasDaSemana diaDaSemana, TimeSpan horaInicio, TimeSpan horaTermino, int tempoDeDescanco)
        {

            if (horaInicio >= horaTermino)
                throw new DomainException("Hora de início não pode ser maior ou igual a hora de termino!");

            if (tempoDeDescanco < 0)
                throw new DomainException("Tempo de descanso não poder ser menor que zero!");

                        
            DiaDaSemana = diaDaSemana;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            TempoDescanso = tempoDeDescanco;

            if (CalculaCargaHoraria() <= 0)
                throw new DomainException("Tempo de descanso não poder ser maior ou igual que a carga horária!");


        }

        protected Escala() { }
        
        public int FuncionarioId { get; private set; }
        public Funcionario Funcionario { get; private set; }
        public DiasDaSemana DiaDaSemana { get; private set; }

        public TimeSpan HoraInicio { get; private set; }
        public TimeSpan HoraTermino { get; private set; }
        public int TempoDescanso { get; private set; }

        public int CalculaCargaHoraria()
        {
            var tempoDescanso = new TimeSpan(TempoDescanso, 0, 0);
            var cargaHoraria = ((HoraTermino - HoraInicio) - tempoDescanso).Hours;
            return cargaHoraria;
        }

    }
}

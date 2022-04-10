using Avaliacao.Domain.RH;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Avaliacao.Application.ViewModels
{
    public class EscalaViewModel
    {
        [Key]
        public int Id { get; set; }

        public int FuncionarioId { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DiasDaSemana DiaDaSemana { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Time)]
        public TimeSpan HoraTermino { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 2, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1} e máximo {2}")]
        public int TempoDescanso { get;  set; }
        public int CargaHoraria { get; set; }

        public static EscalaViewModel ParaEscalaViewModel(Escala escala)
        {
            var escalaViewModel = new EscalaViewModel
            {
                Id = escala.Id,
                FuncionarioId = escala.FuncionarioId,
                DiaDaSemana = escala.DiaDaSemana,
                HoraInicio = escala.HoraInicio,
                HoraTermino = escala.HoraTermino,
                TempoDescanso = escala.TempoDescanso,
                CargaHoraria = escala.CalculaCargaHoraria()
            
            };

            return escalaViewModel;
        }

    }
}

using Avaliacao.Domain.RH;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Avaliacao.Application.ViewModels
{
    public class EstadoViewModel
    {
 
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Sigla { get; set; }



    }
}

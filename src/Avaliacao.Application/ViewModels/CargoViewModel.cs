using Avaliacao.Domain.RH;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Avaliacao.Application.ViewModels
{
    public class CargoViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }


        public static CargoViewModel ParaCargoViewModel(Cargo cargo)
        {
            var cargoViewModel = new CargoViewModel
            {
                Id = cargo.Id,
                Nome = cargo.Nome
            };

   

            return cargoViewModel;
        }
    }
}

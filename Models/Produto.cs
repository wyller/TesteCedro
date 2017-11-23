using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCedro.Models
{
    public class Produto
    {

        [BindRequired]
        public int idProduto { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado")]
        [Display(Name = "Informe o nome do Produto")]
        public string nome { get; set; }

        [Required(ErrorMessage = "A descrição deve ser informada")]
        [Display(Name = "Informe a descrição do produto")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "O valor deve ser informado")]
        public float valor { get; set; }

        [Required(ErrorMessage = "A foto deve ser informada")]
        [Display(Name = "Informe a foto do produto")]
        public string foto { get; set; }

    }
}

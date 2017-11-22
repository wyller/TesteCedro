using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCedro.Models
{
    public class Produto
    {
        public int idProduto { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public float valor { get; set; }
        public string foto { get; set; }

    }
}

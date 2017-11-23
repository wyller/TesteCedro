using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCedro.Models
{
    interface IProduto
    {
        List<Produto> getProdutos();
        void IncluirProduto(Produto produto);
        void AtualizarProduto(Produto produto);
    }
}

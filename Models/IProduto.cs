﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCedro.Models
{
    interface IProduto
    {
        List<Produto> GetProdutos();
        void IncluirProduto(Produto produto);
        void AtualizarProduto(Produto produto);
        void DeletarProduto(int id);
        void DetalharProduto(int id);
        void ComprarProduto(int id);
    }
}

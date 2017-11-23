using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteCedro.Models;

namespace TesteCedro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ProdutoRotas produtos = new ProdutoRotas();
            List<Produto> ListaProdutos = produtos.getProdutos().ToList();
            return View("Lista", ListaProdutos);
        }

        [HttpGet]
        public IActionResult CriarProduto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                ProdutoRotas produtos = new ProdutoRotas();
                produtos.IncluirProduto(produto);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult EditarProduto(int id)
        {
            ProdutoRotas produtoRotas = new ProdutoRotas();
            Produto produto = produtoRotas.getProdutos().Single(x => x.idProduto == id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult EditarProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            ProdutoRotas produtoRotas = new ProdutoRotas();
            produtoRotas.AtualizarProduto(produto);
            return RedirectToAction("Index");
        }

        public IActionResult Lista()
        {
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

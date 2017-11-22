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
            ProdutoLista produtos = new ProdutoLista();
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
            ProdutoLista produtos = new ProdutoLista();
            produtos.IncluirProduto(produto);
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

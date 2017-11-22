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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

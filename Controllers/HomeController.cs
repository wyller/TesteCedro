﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteCedro.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace TesteCedro.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ProdutoRotas produtosRotas = new ProdutoRotas();
            List<Produto> ListaProdutos = produtosRotas.GetProdutos().ToList();
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
                ProdutoRotas produtosRotas = new ProdutoRotas();
                produtosRotas.IncluirProduto(produto);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult EditarProduto(int id)
        {
            ProdutoRotas produtoRotas = new ProdutoRotas();
            Produto produto = produtoRotas.GetProdutos().Single(itemProduto => itemProduto.idProduto == id);
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

        [HttpGet]
        public IActionResult ExcluirProduto(int id)
        {
            ProdutoRotas produtoRotas = new ProdutoRotas();
            Produto produto = produtoRotas.GetProdutos().Single(itemProduto => itemProduto.idProduto == id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult ExcluirProduto(Produto produto)
        {
            ProdutoRotas produtoRotas = new ProdutoRotas();
            produtoRotas.DeletarProduto(produto.idProduto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DetalharProduto(int id)
        {
            ProdutoRotas produtoRotas = new ProdutoRotas();
            Produto produto = produtoRotas.GetProdutos().Single(itemProduto => itemProduto.idProduto == id);
            return View(produto);
        }

        [HttpGet]
        public IActionResult ComprarProduto(int id)
        {
            ProdutoRotas produtoRotas = new ProdutoRotas();
            Produto produto = produtoRotas.GetProdutos().Single(itemProduto => itemProduto.idProduto == id);
            return View(produto);
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

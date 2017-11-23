using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TesteCedro.Services;

namespace TesteCedro.Models
{
    public class ProdutoRotas : IProduto
    {

        public List<Produto> getProdutos()
        {
            var configuration = ConfigurationHalper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefautConnection");

            List<Produto> produtos = new List<Produto>();
            try
            {
                using (SqlConnection con = new SqlConnection(conexaoString))
                {
                    SqlCommand cmd = new SqlCommand("SelectProdutos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Produto produto = new Produto();
                        produto.idProduto = Convert.ToInt32(rdr["idProduto"]);
                        produto.nome = rdr["nome"].ToString();
                        produto.descricao = rdr["descricao"].ToString();
                        produto.valor = Convert.ToInt32(rdr["valor"]);
                        produto.foto = rdr["foto"].ToString();
                        produtos.Add(produto);
                    }
                }
                return produtos;
            }
            catch
            {
                throw;
            }
        }

        public void AtualizarProduto(Produto produto)
        {
            var configuration = ConfigurationHalper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefautConnection");

            using (SqlConnection con = new SqlConnection(conexaoString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("EditarProduto", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramIdProduto = new SqlParameter();
                    paramIdProduto.ParameterName = "@idProduto";
                    paramIdProduto.Value = produto.idProduto;
                    cmd.Parameters.Add(paramIdProduto);

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@nome";
                    paramNome.Value = produto.nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramDescricao = new SqlParameter();
                    paramDescricao.ParameterName = "@descricao";
                    paramDescricao.Value = produto.descricao;
                    cmd.Parameters.Add(paramDescricao);

                    SqlParameter paramValor = new SqlParameter();
                    paramValor.ParameterName = "@valor";
                    paramValor.Value = produto.valor;
                    cmd.Parameters.Add(paramValor);

                    SqlParameter paramFoto = new SqlParameter();
                    paramFoto.ParameterName = "@foto";
                    paramFoto.Value = produto.foto;
                    cmd.Parameters.Add(paramFoto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void IncluirProduto(Produto produto)
        {
            var configuration = ConfigurationHalper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefautConnection");

            using (SqlConnection con = new SqlConnection(conexaoString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("InserirProduto", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@nome";
                    paramNome.Value = produto.nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramDescricao = new SqlParameter();
                    paramDescricao.ParameterName = "@descricao";
                    paramDescricao.Value = produto.descricao;
                    cmd.Parameters.Add(paramDescricao);

                    SqlParameter paramValor = new SqlParameter();
                    paramValor.ParameterName = "@valor";
                    paramValor.Value = produto.valor;
                    cmd.Parameters.Add(paramValor);

                    SqlParameter paramFoto = new SqlParameter();
                    paramFoto.ParameterName = "@foto";
                    paramFoto.Value = produto.foto;
                    cmd.Parameters.Add(paramFoto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void DeletarProduto(int id)
        {
            var configuration = ConfigurationHalper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefautConnection");

            using (SqlConnection con = new SqlConnection(conexaoString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("ExcluirProduto", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramIdProduto = new SqlParameter();
                    paramIdProduto.ParameterName = "@idProduto";
                    paramIdProduto.Value = id;
                    cmd.Parameters.Add(paramIdProduto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}


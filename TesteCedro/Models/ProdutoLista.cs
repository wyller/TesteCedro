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
    public class ProdutoLista : IProduto
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
    }
}

Cedro
=====================

#### Esse é um projeto para uma entrevista de emprego na empresa Cedro

## O que é?

- Esse projeto se trata de um Ecommerce, onde toda sua estrutura foi feita sobre o arquitetura MVC, mapeando um banco relacional(SQL Server).

## O que você precisa ter instalado?

- [DotNet SDK](https://www.microsoft.com/en-us/download/details.aspx?id=15354) para execução no Prompt de comando
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) para o Banco de Dados
- Recomendado->[Visual Studio 2017](https://www.visualstudio.com/pt-br/downloads/?rr=https%3A%2F%2Fwww.google.com.br%2F) como editor de texto
	
## Clone o projeto para sua máquina:

```bash
$ git clone <LINK DO REPOSITÓRIO>
```
- Abra o projeto no Visual Studio 2017.  
- Execute os comando no SQL Server:

```bash
CREATE TABLE produto(
	idProduto int IDENTITY(1,1) NOT NULL primary key,
	nome varchar(75) NOT NULL,
	descricao varchar(150) NOT NULL,
	valor float NOT NULL,
	foto varchar(200) NOT NULL
)
```
```bash
CREATE
PROCEDURE EditarProduto (@idProduto integer, @nome varchar(75), @descricao varchar(150), @valor float, @foto varchar(200))
AS
BEGIN
	update produto 
	set nome = @nome,
	descricao = @descricao,
	valor = @valor,
	foto = @foto
	where idProduto = @idProduto
END
```
```bash
CREATE
PROCEDURE ExcluirProduto(@idProduto integer)
AS
BEGIN
	delete from produto where idProduto = @idProduto
END
```
```bash
CREATE
PROCEDURE InserirProduto(@idProduto integer, @nome varchar(75), @descricao varchar(150), @valor float, @foto varchar(200))
AS
BEGIN
	insert into produto(nome, descricao, valor, foto) values(@nome, @descricao, @valor, @foto)
END
```
```bash
CREATE
PROCEDURE SelectProdutos
AS
BEGIN
	SELECT * from produto
END
```
```bash
CREATE
PROCEDURE SelectUmProduto(@idProduto integer)
AS
BEGIN
	SELECT * from produto where idProduto = @idProduto
END
```
## Conexão com o Banco de Dados
- Troque em appsettings.json no projeto para o servidor local da sua maquina
```bash
"DefautConnection": "Data Source={NOME_DO_SERVIDOR_SQL};Initial Catalog=testeCedro;Integrated Security=True;"
```

## Como funciona a Rota(comportamento do codigo)

- Por se tratar uma arquitetura MVC, o View é onde ocorre as entradas e saidas, que passam pelo Controller que faz a tranzação e as regras de negocios solicitadas e o Model que é o mapeamento do Banco de Dados do SQL Server.

## Exemplo
- Model(Mapeamento)
```bash
namespace TesteCedro.Models
{
    public class Produto
    {
        public int idProduto { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado")]
        [Display(Name = "Informe o nome do Produto")]
        public string nome { get; set; }

        [Required(ErrorMessage = "A descrição deve ser informada")]
        [Display(Name = "Informe a descrição do produto")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "O valor deve ser informado")]
        [Display(Name = "Informe o valor do produto")]
        public float valor { get; set; }

        [Required(ErrorMessage = "A foto deve ser informada")]
        [Display(Name = "Informe o link da foto do produto")]
        public string foto { get; set; }

    }
}
```
- Model
```bash
public List<Produto> GetProdutos()
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
```
- Controler
```bash
public IActionResult Index()
{
    ProdutoRotas produtosRotas = new ProdutoRotas();
    List<Produto> ListaProdutos = produtosRotas.GetProdutos().ToList();
    return View("Lista", ListaProdutos);
}
```
Vida longa e prospera !
=====================

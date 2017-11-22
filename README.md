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
CREATE TABLE usuario(
	idUsuario  int IDENTITY(1,1) NOT NULL,
	nome varchar(100) NOT NULL,
	email varchar(150) NOT NULL,
	admin bit NOT NULL,
	senha varchar(50) NOT NULL
)
```

```bash
CREATE
PROCEDURE EditarProduto
AS
BEGIN
	declare @idProduto integer
	declare @nome varchar(75)
	declare @descricao varchar(150)
	declare @valor float
	declare @foto varchar(200)

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
PROCEDURE ExcluirProduto
AS
BEGIN
	declare @idProduto integer

	delete from produto where idProduto = @idProduto
END
```

```bash
CREATE
PROCEDURE InserirProduto]
AS
BEGIN
	declare @nome varchar(75)
	declare @descricao varchar(150)
	declare @valor float
	declare @foto varchar(200)

	insert into produto(nome, descricao, valor, foto) values(@nome, @descricao, @valor, @foto)
END
```

```bash
CREATE
PROCEDURE InserirUsuario
AS
BEGIN
	declare @email varchar(150)
	declare @nome varchar(100)
	declare @senha varchar(50)
	declare @admin bit

	insert into usuario(nome, email, senha, admin)
	values(@nome, @email, @senha, @admin)
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
PROCEDURE [dbo].[SelectUmProduto]
AS
BEGIN
	declare @idProduto integer
	SELECT * from produto where idProduto = @idProduto
END
```

```bash
CREATE
PROCEDURE [dbo].[SelectUmUsuario]
AS
BEGIN
	declare @idUsuario integer
	SELECT * from usuario where idUsuario = @idUsuario
END
```
## Como funciona a Rota(comportamento do codigo)

- Por se tratar uma arquitetura MVC, o View é onde ocorre as entradas e saidas, que passam pelo Controller que faz a tranzação e as regras de negocios solicitadas e o Model que é o mapeamento do Banco de Dados do SQL Server.



Vida longa e prospera !
=====================

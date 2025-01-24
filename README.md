# movies

Um projeto que catalóga filmes, feito com o propósito para treinar a utilização do ASP.NET Core MVC e o SQL Server.

## Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Instalação](#instalação)
- [Uso](#uso)
- [Funcionalidades](#funcionalidades)
- [Estrutura de Pastas](#estrutura-de-pastas)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Sobre o projeto

Este projeto permite catalogar, buscar e ver informações sobre filmes adicionados no banco, junto com suas imagens e trailers.
Foi criado somente com o propósito para treinar habilidades em ASP.NET Core MVC e o uso do banco SQL Server.

## Tecnologias Utilizadas

- .NET Core 9.0
- ASP.NET Core MVC
- Tailwind CSS, PostCSS e AutoPrefixer
- JavaScript
- SQL Server 20.2
- Node.JS 22.4.1

## Instalação

### Pré-requisitos

- .NET SDK (9.0 ou superior).
- Banco de Dados SQl Server.
- Gerenciador de Pacotes Node.JS/NPM (22.4.1 ou superior)

### Passo a Passo

1. Clone o repositório:
	```bash
	git clone https://github.com/joaoSena0206/movies.git
	```
	
2. Entre na pasta do projeto:
	```bash
	cd movies
	```
	
3. Entre na pasta do banco:
	```bash
	cd banco
	```
	
4. Execute o banco pelo SGBD ou pelo comando abaixo no terminal, substituindo os dados de conexão pelo o que você usa:
	```bash
	sqlcmd -S localhost -U sa -P MinhaSenha123 -d MinhaBaseDeDados -i Criacao.sql
	```
	
5. Volte uma pasta e entre na pasta movies:
	```bash
	cd ..
	cd movies
	```
	
6. Agora abra o arquivo appsettings.json e modifique a linha DefaultConnection com os dados de conexão para o banco:
	```json
	"DefaultConnection": "Server=localhost; Database=imdb; User Id=seuuserid; Password=suasenha; TrustServerCertificate=True"
	```
	
7. Depois disso execute no terminal, para executar o projeto:
	```bash
	dotnet run
	```
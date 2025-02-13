# Prova Prática IA

## Objetivo do projeto

Desenvolvimento de uma API em C# com ASP.NET Core para gerenciar usuários de um arquivo csv e fornecer informações como ID, Nome, Idade, Cidade, Profissão. O cliente Python consome a API e exibe os dados categorizados com o adicional de informação  (jovem <30 anos , adulto 30 a 40 anos, sênior >40 anos )

## Tecnologias utilizadas

- **C#** (ASP.NET Core Web API)
- **Python** (para o cliente)
- **SQL Server** (para o banco de dados)
- **Requests** (biblioteca Python para requisições HTTP)

## Passos para executar a API em C#

### Pré-requisitos
- .NET 6 ou superior
- SQL Server configurado

### Comandos para executar no terminal 
1. No diretório api-csharp.
2.  execute: dotnet restore
   dotnet run

## Passos para executar o cliente em Python

### Pré-requisitos
- Python 3.x ou superior
- Bibliotecas requests instaladas

### Comandos para executar no terminal 
1. No diretório cliente-python.
2.  execute: python app.py


Exemplo de chamadas e respostas da API

1. Na Api C# as informações vai estar disponivel no endpoint:http://localhost:5241/api/users/  e tem a possibilidade de buscar pelo ID ex: http://localhost:5241/api/users/1
   
2. Na aplicação cliente-python no app.py as informações aparecem da seguinte forma:

Nome: Carla Mendes
Idade: 42
Cidade: Belo Horizonte
Profissão: Médica
Categoria: Sênior
------------------------------
Nome: Daniel Santos
Idade: 27
Cidade: Curitiba
Profissão: Desenvolvedor
Categoria: Jovem
------------------------------
Nome: Elisa Ramos
Idade: 31
Cidade: Fortaleza
Profissão: Advogada
Categoria: Adulto
------------------------------

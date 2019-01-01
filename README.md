# Recruting - WebApp

## Preparando o ambiente

A aplicação rodará com .NET Core 2.0

https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.1.202-windows-x64-installer

Ela já está configurada para acessar o caminho: http://localhost:9000

## Sobre a API

A API foi construída em cima do padrão RESTFul com versionamento da API

### Endpoints 

Alguns exemplos de URL para bater na API são:

  http://localhost:9000/v1/vagas
  
  http://localhost:9000/v1/pessoas
  
  http://localhost:9000/v1/candidaturas  
  
  http://localhost:9000/v1/vagas/1/candidaturas/ranking
  

### Arquitetura 

A aplicação foi desenvolvida baseada na Clean Architecture e Dependency Injection (DI) para facilitar a adaptabilidade do código.

Por questões de agilidade, a aplicação roda em cima de Base de Dados em memória (EntityFramework.InMemoryDatabase)


### Algoritmos

O algoritmo utilizado para encontrar o caminho mais curto entre os pontos é feito em cima do algoritmo desenvolvido por Edsger Dijkstra

## Tags

#RESTFulAPI #APIVersioning #.NETCore #ShortestPathTree #Algorithm

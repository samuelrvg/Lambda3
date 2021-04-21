## Copa Games

### (Disclaimer)

Não usei angular ou react por achar que não conseguiria entregar a tempo, pois faz um tempo que não uso essas tecnologias, e como Vue é algo mais recente que estou estudando, resolvi fazer em Vue.

Sobre os testes do Back End não tenho certeza se ficou como o esperado, mas fiz o meu melhor, pois como expliquei na primeira entrevista, estudei muito pouco a parte de testes em projetos pessoais meus, nunca me aprofundei no assunto por não ser uma cultura de muitas empresas atualmente, até então as empresas que já trabalhei não tem essa cultura.

Ainda sobre o Back End, eu não vi a necessidade de criar várias camadas nem mesmo usar injeção de dependência, interfaces etc, como muitos constuman fazer, visto a simplicidade do projeto.

### Iniciando API e Front-End com docker-compose

`docker-compose up`

#### API

http://localhost:8080/swagger/index.html

#### SPA

http://localhost:3000/

#### Testes back-end

`cd Lambda3.Games`
`dotnet test`

#### Estrutura das pastas

- Api
  - Lambda3.Games
    - Lambda3.Games.Api
    - Lambda3.Games.Console
    - Lambda3.Games.Core
    - Lambda3.Games.Test
- SPA
  - CopaGames

#### Principais Tecnologias

- Api
  - .NET Core 3.1
  - Swagger
  - Tests com MSTest
  - Fluent Validator
- Front End
  - NuxtJs
  - Lodash
  - Bootstrap

#### O que pode ser melhorado

- Melhorar algoritmo de classificação dos games para ficar dinâmico, assim evita de passar o index manualmente de cada elemento do grupo.
- Alterar visibilidade do método CompararJogos para private, não alterei para facilitar os testes. Usar Reflection ou Injeção de Dependência são soluções possíveis.
- Executar testes juntamente com containers do docker.
- Adicionar tests para GameValidator

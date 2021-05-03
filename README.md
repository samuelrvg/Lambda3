## Copa Games

### (Disclaimer)

Motivo de não usar angular ou react no front-end foi por achar que não conseguiria entregar a tempo, pois faz um tempo que não uso essas tecnologias, e como Vue é algo mais recente que estou estudando, resolvi fazer em Vue.

Sobre os testes do Back End não tenho certeza se ficou como o esperado, mas fiz o meu melhor, pois como expliquei na primeira entrevista, estudei muito pouco a parte de testes em projetos pessoais meus, nunca me aprofundei no assunto por não fazer parte da cultura das empresas que já trabalhei.

### Iniciando API e Front-End com docker-compose

```sh
docker-compose up
```

#### API

http://localhost:8080/swagger/index.html

#### SPA

http://localhost:3000/

#### Testes back-end

```sh
cd Lambda3.Games
dotnet test
```

#### Estrutura das pastas

- Api
  - Lambda3.Games
    - Lambda3.Games.Api
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

- Configurar variaveis de ambiente
- Configurar certificado no container da api para permitir https
- Executar testes juntamente com containers do docker.
- FluentValidator retorna lista de errors muito grande, simplificar retorno.
- Adicionar tests para GameValidator

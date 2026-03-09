# MinhaApi

API REST desenvolvida em **ASP.NET Core (C#)** com o objetivo de
**simular respostas baseadas em arquivos JSON** a partir de dados
enviados no corpo da requisição.

Essa abordagem é útil para **mock de serviços**, **testes de
integração**, **prototipação de front-end** e **simulação de respostas
de sistemas externos**.

------------------------------------------------------------------------

# 📌 Visão Geral

A API recebe uma requisição HTTP contendo um JSON no corpo.\
A partir desse JSON, o sistema identifica o valor do campo **estado** e
busca um arquivo JSON correspondente para retornar como resposta.

Exemplo:

Se a requisição enviar:

``` json
{
  "estado": "WELCOME"
}
```

A API tentará carregar:

    WELCOME.json

Caso o arquivo exista, seu conteúdo será retornado como resposta da API.

------------------------------------------------------------------------

# 🧰 Tecnologias Utilizadas

-   **.NET / ASP.NET Core**
-   **C#**
-   **System.Text.Json**
-   **Logging com ILogger**
-   **Arquivos JSON para mock de respostas**

------------------------------------------------------------------------

# 🏗 Estrutura do Projeto

    MinhaApi
    │
    ├── Controllers
    │   └── AcoesController.cs
    │
    ├── Utils
    │   └── Utils.cs
    │
    ├── MinhaApi.csproj
    └── MinhaApi.sln

### Controller Principal

**AcoesController**

Responsável por:

-   Receber requisições HTTP POST
-   Ler o JSON enviado
-   Extrair o campo `estado`
-   Buscar um arquivo JSON correspondente
-   Retornar o conteúdo como resposta

------------------------------------------------------------------------

# 🚀 Endpoint da API

## POST `/api/acoes`

Recebe um JSON contendo o campo **estado**.

### Exemplo de Requisição

``` json
{
  "estado": "WELCOME"
}
```

### Fluxo da Requisição

1.  A API recebe o JSON no corpo da requisição.
2.  O conteúdo é registrado no log da aplicação.
3.  O sistema captura o valor do campo **estado**.
4.  Um arquivo JSON com o nome do estado é procurado.
5.  Se o arquivo existir, seu conteúdo é retornado.
6.  Caso contrário, a API retorna erro **404**.

------------------------------------------------------------------------

# 📥 Exemplo de Resposta

Se existir um arquivo:

    WELCOME.json

A resposta poderá ser:

``` json
{
  "mensagem": "Resposta simulada para o estado WELCOME"
}
```

------------------------------------------------------------------------

# ⚠️ Tratamento de Erros

### 404 - Arquivo não encontrado

Retornado quando não existe um arquivo JSON correspondente ao estado
informado.

    Arquivo JSON não encontrado.

------------------------------------------------------------------------

# 📊 Logs

A API registra logs importantes para auditoria e depuração:

-   JSON recebido na requisição
-   Estado extraído do payload

Isso facilita o **monitoramento e troubleshooting** da aplicação.

------------------------------------------------------------------------

# ▶️ Como Executar o Projeto

## 1. Clonar o repositório

``` bash
git clone https://github.com/seu-usuario/minhaapi.git
```

## 2. Acessar o diretório do projeto

``` bash
cd MinhaApi
```

## 3. Restaurar dependências

``` bash
dotnet restore
```

## 4. Executar a aplicação

``` bash
dotnet run
```

A API ficará disponível normalmente em:

    http://localhost/api/Acoes

------------------------------------------------------------------------

# 🧪 Testando a API

Você pode testar utilizando:

-   **Postman**
-   **Insomnia**
-   **curl**
-   **Swagger (caso habilitado)**

Exemplo com curl:

``` bash
curl -X POST http://localhost/api/Acoes -H "Content-Type: application/json" -d '{"estado":"WELCOME"}'
```

------------------------------------------------------------------------

# 🔮 Melhorias Futuras

Possíveis evoluções do projeto:

-   Integração com **Swagger / OpenAPI**
-   Validação de entrada com **FluentValidation**
-   Implementação de **cache para respostas**
-   Estruturação com **Clean Architecture**
-   Testes automatizados (**xUnit / NUnit**)
-   Containerização com **Docker**

------------------------------------------------------------------------

# 👨‍💻 Autor

Douglas Alvares
https://www.linkedin.com/in/douglas-alvares-a66601b2/

------------------------------------------------------------------------

# 📄 Licença

Este projeto pode ser utilizado livremente para fins de estudo, testes e
desenvolvimento.

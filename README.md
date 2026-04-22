# Projeto RPA de Criptomoedas - API REST

## Introdução

O **Projeto RPA de Criptomoedas** é um robô de automação que extrai informações de uma API pública de criptomoedas, mantendo os dados sempre atualizados em um banco de dados local.  
A aplicação consulta automaticamente a API externa e persiste as informações, garantindo que os dados estejam sempre sincronizados.

---

## Objetivo do Sistema

O sistema realiza a coleta e atualização contínua de dados de criptomoedas, expondo as informações via API REST para consulta.  
Principais objetivos:

- Extração automatizada de dados de uma API pública de criptomoedas.
- Persistência e atualização dos dados em banco de dados relacional.
- Exposição dos dados via endpoints REST para consulta.
- Execução containerizada para facilitar deploy e portabilidade.

---

## Tecnologias Utilizadas

- **.NET Core 10**: framework principal para desenvolvimento da API e do robô de automação.
- **Docker**: containerização da aplicação e do banco de dados para execução simplificada.
- **PostgreSQL**: banco de dados relacional para persistência dos dados das criptomoedas.
- **Entity Framework Core**: ORM para mapeamento e interação com o banco de dados PostgreSQL.
- **Swagger / OpenAPI**: documentação interativa da API.

---

## Estrutura do Projeto

O projeto adota uma **arquitetura em camadas**, integrando um robô RPA com uma API REST:

- **RPA**: responsável por consumir a API pública de criptomoedas e atualizar os dados no banco.
- **Infrastructure**: responsável pelo compartilhamento de informações do banco para outras camadas
- **Domain**: responsável pelo compartilhamento de informações de regra de negócio para outras camadas
- **API REST**: expõe os dados persistidos para consulta externa via endpoints documentados.

---

## Funcionalidades Principais

- **Extração Automatizada**: o robô consulta a API pública de criptomoedas a cada 60 segundos e mantém os dados atualizados.
- **Persistência de Dados**: informações salvas e atualizadas no PostgreSQL via Entity Framework Core.
- **Consulta de Moedas**: listagem de todas as criptomoedas disponíveis.
- **Consulta por ID**: busca de uma criptomoeda específica pelo seu identificador.

---

## Endpoints Disponíveis

### 🪙 Criptomoedas

| Método | Endpoint       | Descrição                             | Parâmetros         | Respostas     |
|--------|----------------|---------------------------------------|--------------------|---------------|
| **GET**    | `/Coin`        | Retorna todas as criptomoedas         | —                  | `200`, `500`  |
| **GET**    | `/Coin/{id}`   | Retorna uma criptomoeda pelo ID       | `id` (ex: `bitcoin`) | `200`, `500` |

> **Exemplo de ID:** `bitcoin`, `ethereum`, `solana`

---

## Instruções de Uso

### Pré-requisitos

- [Docker](https://www.docker.com/get-started) instalado na máquina.

> **Observação sobre a API Key:** a chave de acesso à API pública está configurada diretamente no código, em `HttpClientConfiguration`. Este método não é recomendado para ambientes de produção — o correto seria utilizar um arquivo `.env` com variáveis de ambiente criptografadas no servidor. Para fins de demonstração e avaliação, a chave foi mantida no código para facilitar a execução.

### Execução

1. Abra um terminal na pasta raiz do projeto.

2. Execute o comando abaixo para subir todos os serviços:

    ```bash
    docker compose up -d
    ```

3. Aguarde os containers iniciarem. O banco de dados e a API serão configurados automaticamente.

---

## Documentação

- **Swagger / OpenAPI:** a documentação interativa da API está disponível após a execução, acessível via `/swagger`. Permite explorar e testar os endpoints diretamente pelo navegador.


## Possíveis melhorias
- Implementar testes automatizados (unitários e de integração) para validar a comunicação com a API e garantir a estabilidade das chamadas externas.
- Adicionar um mecanismo de monitoramento do Worker, enviando seu status de execução (com base nos logs ou checkpoints) para a API, permitindo acompanhamento de sucesso, falhas e tempo de processamento.
- Estruturar logs mais detalhados e centralizados (ex: correlação por request), facilitando debug e observabilidade.


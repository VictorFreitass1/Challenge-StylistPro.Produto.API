# StylistPro.Produto.API

## Integrantes
- RM98695  - Breno Giacoppini Câmara   
- RM551744 - Jaqueline Martins dos Santos   
- RM97510  - Mariana Bastos Esteves   
- RM551155 - Matheus Oliveira Macedo   
- RM99982  - Victor Freitas Silva   

## Visão Geral
Esta API foi desenvolvida utilizando uma arquitetura de microservices e segue os princípios de um sistema escalável e modular. As principais funcionalidades incluem operações CRUD (Create, Read, Update e Delete) com banco de dados ORACLE e a documentação da API configurada com OpenAPI. Também foram aplicados padrões de design como Singleton e a arquitetura Onion, além de práticas de Clean Code e SOLID.

### Funcionalidades Adicionais
- **Integração com Serviço Externo**: A API consome o serviço ViaCEP via RESTful para consultas de CEP, adicionando maior integração e dados contextualizados à aplicação.
- **Testes Unitários**: Implementados na camada de ApplicationService e Repository para garantir a robustez e a confiabilidade das operações.
- **Inteligência Artificial (IA)**: A API integra o ML.NET para fornecer recomendações de produtos. Essa funcionalidade utiliza um modelo de aprendizado de máquina que agrega valor ao usuário, oferecendo sugestões personalizadas com base no histórico e nas preferências de consumo.

## Estrutura de Camadas

- **Presentation Layer (Camada de Apresentação)**: Gerencia a comunicação entre o cliente e a aplicação. Utilizamos o ASP.NET Core para expor os endpoints da API.
- **Application Layer (Camada de Aplicação)**: Contém a lógica de negócios de alto nível, coordenando operações entre a camada de domínio e a camada de apresentação.
- **Domain Layer (Camada de Domínio)**: Define as entidades de domínio e as regras de negócios centrais.
- **Infrastructure Layer (Camada de Infraestrutura)**: Gerencia tecnologias externas como banco de dados e integrações com serviços externos.
- **Test Layer (Camada de Testes)**: Inclui testes unitários e de integração utilizando xUnit para garantir o comportamento correto da aplicação

## Clean Code 

- **Clean Code** é um conjunto de boas práticas e princípios para escrever códigos legíveis, simples, e fáceis de manter facilitando a manutenção e evolução do sistema. Alguns dos princípios básicos incluem:
- **Nomes significativos**: Os nomes de variáveis, métodos, classes e outros elementos do código devem ser descritivos e deixar claro seu propósito.
- **Funções pequenas e de única responsabilidade**: Funções devem ser curtas e fazer apenas uma coisa. Elas devem ser simples de entender e ter um único propósito.
- **Remoção de código Morto**: Código não utilizado ou comentado deve ser removido para evitar confusão e manter o código limpo. 
- **Tratamento de erros claro**: Exceções e validações ajudam a evitar comportamentos inesperados e facilitam a identificação de problemas.
- **Evite Dependências Ocultas**: O código deve ser claro sobre quais dados ele precisa. Depender de variáveis globais ou de comportamentos que não são explícitos pode gerar bugs difíceis de identificar. 

## SOLID
  
- **SRP (Single Responsibility Principle)**: Cada classe tem uma única responsabilidade.
- **OCP (Open/Closed Principle)**: Módulos são abertos para extensão e fechados para modificação.
- **LSP (Liskov Substitution Principle)**: Classe e interface específica para casos de uso.
- **ISP (Dependency Inversion Principle)**: Princípio da segregação de interfaces.
- **DIP (Dependency Inversion Principle)**: Inversão de dependências torna o sistema mais modular.

## Testes Unitários
- Testes unitários foram implementados nas camadas `ApplicationService` e `Repository` para verificar o funcionamento correto e a integridade dos dados, aumentando a robustez e confiabilidade da API.

## Design Patterns Utilizados

### 1. Singleton
O padrão Singleton foi utilizado para garantir que algumas classes críticas, como a de conexão com o banco de dados, tenham apenas uma instância ao longo da execução, economizando recursos.

### 2. Microservices
A API adota uma arquitetura de microservices para oferecer escalabilidade e modularidade. Cada serviço opera de forma independente, promovendo uma estrutura resiliente e fácil de manter.

## Arquitetura

A arquitetura apresentada para o projeto **StylistPro** segue os princípios da **Onion Architecture**, para uma alta desacoplagem entre camadas.

## Tecnologias Utilizadas
- **Oracle Database**: Para operações CRUD.
- **ASP.NET Core**: Framework para desenvolvimento da API.
- **OpenAPI/Swagger**: Configurado para a documentação da API.
- **ML.NET**: Ferramenta de machine learning para recomendações de produtos.
- **xUnit**: para testes automatizados
- **ViaCEP API**: Para integração com CEPs.

## Requisitos
- **.NET SDK 8.0**
- **Visual Studio 2022 ou Visual Studio Code**
- **Oracle Database (com conexão configurada)**
- **Ferramenta de gerenciamento de dependências**

## Instruções para Executar a API

### 1. Clone o repositório:
```
git clone <link-do-repositorio>
```

### 2. Navegue até a pasta do projeto:
```
cd StylistPro.Produto.API
```

### 3. Restaure os pacotes NuGet:
```
dotnet restore
```

### 4. Configure a string de conexão com o banco de dados ORACLE no arquivo appsettings.json:
```
"ConnectionStrings": {
  "Oracle": "Data Source=<oracle-db-url>;User Id=<username>;Password=<password>;"
}
```

### 5. Execute a aplicação:
```
dotnet run
```

### 6. Acesse a documentação da API gerada pelo Swagger:
```
Após executar a API, navegue até http://localhost:<porta>/swagger para visualizar e interagir com a documentação.
```

### 7. No caso de erro no banco de dados: Se houver inconsistências entre o código e o banco de dados, você pode gerar e aplicar migrations para corrigir a estrutura do banco.
```
Remove-Migration
```
```
Add-Migration <nome-da-migração>
```
```
Update-Database
```

## Testando a API
A **StylistPro** utiliza o Swagger para expor os endpoints de forma interativa. Abra a URL fornecida após executar a API e você verá a documentação da API com opções para testar cada endpoint.

## Contato
Para qualquer dúvida ou sugestão, entre em contato com victor.fsilva45@gmail.com

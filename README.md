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

## Práticas de Clean Code e SOLID
As práticas de Clean Code foram aplicadas para assegurar a clareza e a simplicidade do código, promovendo uma estrutura modular e de fácil manutenção. Os princípios SOLID foram integrados da seguinte forma:
- **Single Responsibility Principle (SRP)**: Cada classe na API tem uma única responsabilidade.
- **Open-Closed Principle (OCP)**: Componentes estão abertos para extensão e fechados para modificação, facilitando a adição de novas funcionalidades.
- **Liskov Substitution Principle (LSP)**: Implementação de interfaces e herança respeitam as substituições esperadas.
- **Interface Segregation Principle (ISP)**: Interfaces específicas para cada funcionalidade evitam dependências desnecessárias.
- **Dependency Inversion Principle (DIP)**: Inversão de dependência é usada para desacoplar a lógica de negócio da infraestrutura.

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

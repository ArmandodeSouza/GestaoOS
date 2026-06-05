# GestãoOS

Sistema desktop para gerenciamento de Ordens de Serviço desenvolvido em Windows Forms, utilizando .NET Framework 4.6.1 e PostgreSQL.

## Arquitetura Adotada

O projeto foi estruturado em camadas visando separação de responsabilidades, baixo acoplamento e facilidade de manutenção.

### Camadas

#### GestaoOS.UI

Responsável pela interface do usuário.

Principais responsabilidades:

* Formulários Windows Forms
* Interação com o usuário
* Validações visuais
* Exibição de relatórios

#### GestaoOS.Application

Responsável pela orquestração dos casos de uso.

Principais responsabilidades:

* DTOs
* Interfaces de serviços
* Interfaces de repositórios
* Regras de aplicação

#### GestaoOS.Domain

Responsável pelas regras de negócio.

Principais responsabilidades:

* Entidades
* Value Objects
* Enumerações de domínio
* Validações de negócio

#### GestaoOS.Infrastructure

Responsável pelo acesso a dados e integrações externas.

Principais responsabilidades:

* Repositórios
* Conexão com PostgreSQL
* Consultas SQL
* Persistência dos dados

---

## Decisões Técnicas

### Windows Forms

Foi utilizado Windows Forms por ser requisito obrigatório do teste e por ser amplamente utilizado em sistemas corporativos legados.

### PostgreSQL

Banco de dados relacional escolhido por sua robustez, estabilidade e recursos avançados.

### ADO.NET com Npgsql

O acesso aos dados foi implementado utilizando Npgsql e comandos SQL nativos.

Motivos:

* Controle total sobre consultas
* Baixa complexidade
* Melhor entendimento do fluxo de persistência
* Atende aos requisitos do teste

### Repository Pattern

Os repositórios encapsulam o acesso ao banco de dados, evitando que a interface tenha conhecimento da camada de persistência.

### Service Layer

Os serviços concentram as regras de negócio e validações antes das operações de persistência.

### DTOs

Foram utilizados DTOs para comunicação entre camadas, evitando exposição direta das entidades de domínio para a interface.

### ReportViewer (RDLC)

Utilizado para geração de relatórios gerenciais.

Recursos implementados:

* Filtros dinâmicos
* Agrupamentos
* Totais
* Exportação para PDF

---

## Estratégia de Concorrência

Foi adotada concorrência otimista através do campo:

```sql
versao
```
presente na entidade Ordem de Serviço.

Objetivos:

* Evitar sobrescrita acidental de alterações
* Detectar atualizações simultâneas
* Garantir consistência dos dados

A atualização de registros considera a versão atual do objeto antes da persistência.

---

## Auditoria e Rastreabilidade

Para garantir rastreabilidade das operações realizadas no sistema, foram implementadas funções e triggers no PostgreSQL responsáveis pelo registro automático de auditoria.

### Objetivos

- Registrar alterações críticas de dados
- Manter histórico de operações
- Auxiliar em análises e suporte
- Permitir rastreamento de mudanças

### Estratégia Utilizada

Foram criadas funções PL/pgSQL associadas a triggers executadas automaticamente em operações de:

- INSERT
- UPDATE
- DELETE

As triggers registram informações relevantes da operação, como:

- Tabela afetada
- Tipo da operação
- Data e hora
- Registro alterado
- Valores anteriores e novos (quando aplicável)

### Benefícios

- Auditoria centralizada no banco de dados
- Independência da camada de aplicação
- Garantia de registro mesmo em operações futuras realizadas por outros sistemas
- Maior confiabilidade para análise de alterações

## Funcionalidades Implementadas

### Clientes

* Cadastro
* Edição
* Exclusão
* Pesquisa
* Controle de ativo/inativo
* Validação de documento único
* Bloqueio de exclusão quando existir Ordem de Serviço vinculada

### Serviços

* Cadastro
* Edição
* Exclusão
* Pesquisa
* Controle de impostos

### Ordens de Serviço

* Abertura
* Alteração
* Cancelamento
* Conclusão
* Reabertura
* Histórico de status
* Controle de itens
* Recalculo automático dos valores

### Relatórios

* Relatório de Ordens de Serviço
* Filtro por período
* Filtro por cliente
* Filtro por status
* Agrupamento por cliente
* Total por cliente
* Total geral
* Total de impostos
* Quantidade de OS
* Exportação PDF

---
### Requisitos atendidos

- Cadastro, edição, pesquisa e exclusão de clientes
- Validação de documento único
- Bloqueio de exclusão de cliente com OS vinculada
- Cadastro e manutenção de serviços
- Controle de Valor Base e de Imposto
- Cadastro e manutenção de Ordens de Serviço
- Itens de OS com cálculo de imposto
- Recalculo automático do valor total da OS
- Controle de status da OS
- Conclusão, cancelamento e reabertura de OS
- Histórico de alteração de status
- Controle de concorrência otimista por campo Versao
- Operações de OS realizadas com transação
- Rollback em caso de falha
- Listagens com paginação
- Carregamento de itens apenas ao abrir a OS
- Acesso a dados com NpgsqlConnection e NpgsqlCommand
- Uso de parâmetros nomeados
- Separação em UI, Services, Repositories, Entities e Infrastructure
- Tratamento de erros com mensagens amigáveis
- Registro de logs em arquivo
- Relatório ReportViewer com filtros por período, cliente e status
- Agrupamento do relatório por cliente
- Total por cliente
- Total geral
- Total de impostos
- Quantidade total de OS no período
- Exportação do relatório para PDF
- Script SQL com PK e FK
- Índices para pesquisa
- Constraints de integridade
- Unique Constraints
- Functions PL/pgSQL
- Triggers de auditoria
- Controle de histórico de alterações

## Como Rodar o Projeto

### Pré-requisitos

* Visual Studio 2022 ou superior
* .NET Framework 4.6.1
* PostgreSQL
* Npgsql
* Microsoft ReportViewer

### Passos

#### 1. Criar banco de dados

Executar o script SQL disponibilizado no projeto.

#### 2. Configurar string de conexão

Atualizar o arquivo:

```text
App.config
```

#### 3. Restaurar pacotes NuGet

No Visual Studio:

```text
Build
→ Restore NuGet Packages
```

#### 4. Compilar a solução

```text
Build
→ Rebuild Solution
```

#### 5. Executar

Definir o projeto UI como Startup Project e iniciar a aplicação.

---

## Exemplo de String de Conexão

```xml
<connectionStrings>
  <add
      name="GestaoOS"
      connectionString="Host=localhost;Port=5432;Database=gestao_os;Username=postgres;Password=123456"
      providerName="Npgsql" />
</connectionStrings>
```

---

## Tecnologias Utilizadas

* C#
* .NET Framework 4.6.1
* Windows Forms
* PostgreSQL
* Npgsql
* ReportViewer RDLC
* SQL
* Git

---

## Autor

Armando de Souza Reche Modenês

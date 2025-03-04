# 💳 Gestão de Transações Financeiras 

Esse aplicação permite o **gerenciamento de transações de cartões de crédito**, incluindo cadastro, edição, exclusão, consultas avançadas e exportação de relatórios para **Excel**, utilizando **VB.NET** e **SQL Server**.

---

## 🚀 **Funcionalidades Implementadas**
1️⃣ **CRUD Completo**: Inserir, editar, excluir e consultar transações com filtros avançados.  
2️⃣ **Stored Procedure SQL**: Cálculo total de transações por período, agrupado por número do cartão.  
3️⃣ **Function SQL**: Categorização de transações com base no valor.  
4️⃣ **View SQL**: Combinação de informações de transações e clientes para consultas otimizadas.  
5️⃣ **Exportação para Excel**: Relatórios detalhados com filtro por período.  

---

## 🛠 **Tecnologias Utilizadas**
- **Linguagem:** VB.NET (Windows Forms)
- **Banco de Dados:** SQL Server
- **ORM:** Entity Framework Core
- **Exportação Excel:** ClosedXML (dispensa dependência do Microsoft Office)

---

## 📸 Screenshots

### Main Screen
![Form1](https://github.com/user-attachments/assets/73787f55-ccde-45b8-8997-dc2af8bef854)


## 🏗 **Configuração do Banco de Dados**
Antes de rodar o projeto, **execute o seguinte script SQL** para criar e popular as tabelas:

```sql
-- Criar o banco de dados (se ainda não existir)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'GestaoFinanceiro')
BEGIN
    CREATE DATABASE GestaoFinanceiro;
END;
GO

USE GestaoFinanceiro;
GO

-- Criar Tabela Clientes
IF OBJECT_ID('Clientes', 'U') IS NOT NULL
    DROP TABLE Clientes;
GO

CREATE TABLE Clientes (
    Id_Cliente INT PRIMARY KEY IDENTITY(1,1),
    Nome_Cliente VARCHAR(100) NOT NULL,
    Numero_Cartao VARCHAR(16) UNIQUE
);
GO

-- Criar Tabela Transacoes
IF OBJECT_ID('Transacoes', 'U') IS NOT NULL
    DROP TABLE Transacoes;
GO

CREATE TABLE Transacoes (
    Id_Transacao INT PRIMARY KEY IDENTITY(1,1),
    Numero_Cartao VARCHAR(16) NULL,
    Valor_Transacao MONEY NOT NULL,
    Data_Transacao DATE NOT NULL,
    Descricao VARCHAR(200)
);
GO

-- Criar Stored Procedure para totalizar transações por período
IF OBJECT_ID('sp_TotalTransacoesPorPeriodo', 'P') IS NOT NULL
    DROP PROCEDURE sp_TotalTransacoesPorPeriodo;
GO

CREATE PROCEDURE [dbo].[sp_TotalTransacoesPorPeriodo]
    @Data_Inicial DATE,
    @Data_Final DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Numero_Cartao,
        SUM(Valor_Transacao) AS Valor_Total,
        COUNT(*) AS Quantidade_Transacoes
    FROM Transacoes
    WHERE Data_Transacao BETWEEN @Data_Inicial AND @Data_Final
    GROUP BY Numero_Cartao
    ORDER BY Valor_Total DESC;
END;
GO

-- Criar Function para categorizar transações
IF OBJECT_ID('fn_CategorizarTransacao', 'FN') IS NOT NULL
    DROP FUNCTION fn_CategorizarTransacao;
GO

CREATE FUNCTION [dbo].[fn_CategorizarTransacao] (@Valor MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
    RETURN 
        CASE 
            WHEN @Valor > 1000 THEN 'Alta'
            WHEN @Valor BETWEEN 500 AND 1000 THEN 'Média'
            ELSE 'Baixa'
        END;
END;
GO

-- Criar View para combinar Clientes e Transações
IF OBJECT_ID('vw_TransacoesDetalhadas', 'V') IS NOT NULL
    DROP VIEW vw_TransacoesDetalhadas;
GO

CREATE VIEW [dbo].[vw_TransacoesDetalhadas] AS
SELECT
    c.Nome_Cliente,
    t.Numero_Cartao,
    t.Valor_Transacao,
    t.Data_Transacao,
    t.Descricao,
    dbo.fn_CategorizarTransacao(t.Valor_Transacao) AS Categoria
FROM Transacoes t
LEFT JOIN Clientes c ON t.Numero_Cartao = c.Numero_Cartao;
GO
```

# ▶️ Como Executar o Projeto
## 1️⃣ Instalar Dependências
Antes de rodar a aplicação, instale as bibliotecas necessárias via NuGet:
```
dotnet restore
```

## 2️⃣ Configurar a Conexão com o Banco
No arquivo app.config, ajuste a string de conexão para a correta de acordo com o caminho do seu banco, usuário e senha:

```
    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlServer("Server=SEU-SERVIDOR;Database=GestaoFinanceiro;User Id=SEU-USUARIO;Password=SUA-SENHA;TrustServerCertificate=True")
    End Sub
```

## 3️⃣ Executar a Aplicação

Abra o projeto no Visual Studio.
Compile e rode o projeto (F5).
Utilize a interface para cadastrar, filtrar e exportar transações.

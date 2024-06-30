-- Verifica se o banco de dados existe antes de criá-lo
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'Hipermercado')
BEGIN
    CREATE DATABASE Hipermercado;
    PRINT 'Banco de dados Hipermercado criado com sucesso.';
END
ELSE
BEGIN
    PRINT 'O banco de dados Hipermercado já existe.';
END
GO

-- Utiliza o banco de dados Hipermercado
USE Hipermercado;
GO

-- Verifica e cria a tabela TipoProduto se não existir
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'TipoProduto')
BEGIN
    CREATE TABLE TipoProduto (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Tipo VARCHAR(50) NOT NULL UNIQUE
    );
    PRINT 'Tabela TipoProduto criada com sucesso.';
END
ELSE
BEGIN
    PRINT 'A tabela TipoProduto já existe.';
END
GO

-- Verifica e cria a tabela ElementoEstoque se não existir
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ElementoEstoque')
BEGIN
    CREATE TABLE ElementoEstoque (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Preco DECIMAL(10, 2) NOT NULL,
        CnpjFabricante VARCHAR(50) NOT NULL,
        Custo DECIMAL(10, 2) NOT NULL
    );
    PRINT 'Tabela ElementoEstoque criada com sucesso.';
END
ELSE
BEGIN
    PRINT 'A tabela ElementoEstoque já existe.';
END
GO

-- Verifica e cria a tabela Estoque se não existir
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Estoque')
BEGIN
    CREATE TABLE Estoque (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Quantidade INT NOT NULL,
        Id_ElementoEstoque INT NOT NULL,
        CONSTRAINT FK_Estoque_ElementoEstoque FOREIGN KEY (Id_ElementoEstoque) REFERENCES ElementoEstoque(Id)
    );
    PRINT 'Tabela Estoque criada com sucesso.';
END
ELSE
BEGIN
    PRINT 'A tabela Estoque já existe.';
END
GO

-- Verifica e cria a tabela Alimento se não existir
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Alimento')
BEGIN
    CREATE TABLE Alimento (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        DataValidade DATETIME NOT NULL,
        Nome VARCHAR(200) NOT NULL,
        Peso DECIMAL(5, 2) NOT NULL,
        Id_ElementoEstoque INT,
        CONSTRAINT FK_Alimento_ElementoEstoque FOREIGN KEY (Id_ElementoEstoque) REFERENCES ElementoEstoque(Id)
    );
    PRINT 'Tabela Alimento criada com sucesso.';
END
ELSE
BEGIN
    PRINT 'A tabela Alimento já existe.';
END
GO

-- Verifica e cria a tabela ProdutoLimpeza se não existir
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ProdutoLimpeza')
BEGIN
    CREATE TABLE ProdutoLimpeza (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        DataValidade DATETIME NOT NULL,
        Nome VARCHAR(200) NOT NULL,
        Volume DECIMAL(5, 2) NOT NULL,
        Id_ElementoEstoque INT,
        CONSTRAINT FK_ProdutoLimpeza_ElementoEstoque FOREIGN KEY (Id_ElementoEstoque) REFERENCES ElementoEstoque(Id)
    );
    PRINT 'Tabela ProdutoLimpeza criada com sucesso.';
END
ELSE
BEGIN
    PRINT 'A tabela ProdutoLimpeza já existe.';
END
GO

-- Verifica e cria a tabela PesquisaMercado se não existir
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'PesquisaMercado')
BEGIN
    CREATE TABLE PesquisaMercado (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Satisfacao INT NOT NULL CHECK (Satisfacao BETWEEN 0 AND 100),
        InstitutoPesquisa VARCHAR(200) NOT NULL,
        Id_ProdutoLimpeza INT,
        CONSTRAINT FK_PesquisaMercado_ProdutoLimpeza FOREIGN KEY (Id_ProdutoLimpeza) REFERENCES ProdutoLimpeza(Id)
    );
    PRINT 'Tabela PesquisaMercado criada com sucesso.';
END
ELSE
BEGIN
    PRINT 'A tabela PesquisaMercado já existe.';
END
GO
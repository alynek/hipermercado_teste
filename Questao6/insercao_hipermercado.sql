-- Inserção na tabela ElementoEstoque
IF NOT EXISTS (SELECT 1 FROM ElementoEstoque WHERE Preco = 10.99 AND CnpjFabricante = '123456789' AND Custo = 5.99)
BEGIN
    INSERT INTO ElementoEstoque (Preco, CnpjFabricante, Custo)
    VALUES (10.99, '123456789', 5.99);
END

IF NOT EXISTS (SELECT 1 FROM ElementoEstoque WHERE Preco = 8.50 AND CnpjFabricante = '987654321' AND Custo = 4.75)
BEGIN
    INSERT INTO ElementoEstoque (Preco, CnpjFabricante, Custo)
    VALUES (8.50, '987654321', 4.75);
END

IF NOT EXISTS (SELECT 1 FROM ElementoEstoque WHERE Preco = 15.75 AND CnpjFabricante = '456789123' AND Custo = 9.25)
BEGIN
    INSERT INTO ElementoEstoque (Preco, CnpjFabricante, Custo)
    VALUES (15.75, '456789123', 9.25);
END

IF NOT EXISTS (SELECT 1 FROM ElementoEstoque WHERE Preco = 20.00 AND CnpjFabricante = '111111111' AND Custo = 8.55)
BEGIN
    INSERT INTO ElementoEstoque (Preco, CnpjFabricante, Custo)
    VALUES (20.00, '111111111', 8.55);
END

IF NOT EXISTS (SELECT 1 FROM ElementoEstoque WHERE Preco = 18 AND CnpjFabricante = '111111111' AND Custo = 9.25)
BEGIN
    INSERT INTO ElementoEstoque (Preco, CnpjFabricante, Custo)
    VALUES (18, '111111111', 9.25);
END

IF NOT EXISTS (SELECT 1 FROM ElementoEstoque WHERE Preco = 21.00 AND CnpjFabricante = '191111345' AND Custo = 8.55)
BEGIN
    INSERT INTO ElementoEstoque (Preco, CnpjFabricante, Custo)
    VALUES (21.00, '191111345', 8.55);
END

-- Inserção na tabela ProdutoLimpeza
IF NOT EXISTS (SELECT 1 FROM ProdutoLimpeza WHERE DataValidade = '2024-08-20' AND Nome = 'Detergente' AND Volume = 500 AND Id_ElementoEstoque = 1)
BEGIN
    INSERT INTO ProdutoLimpeza (DataValidade, Nome, Volume, Id_ElementoEstoque)
    VALUES ('2024-08-20', 'Detergente', 500, 1);
END

IF NOT EXISTS (SELECT 1 FROM ProdutoLimpeza WHERE DataValidade = '2024-07-25' AND Nome = 'Desinfetante' AND Volume = 200 AND Id_ElementoEstoque = 2)
BEGIN
    INSERT INTO ProdutoLimpeza (DataValidade, Nome, Volume, Id_ElementoEstoque)
    VALUES ('2024-07-25', 'Desinfetante', 200, 2);
END

IF NOT EXISTS (SELECT 1 FROM ProdutoLimpeza WHERE DataValidade = '2024-09-10' AND Nome = 'Sabão em Pó' AND Volume = 700 AND Id_ElementoEstoque = 3)
BEGIN
    INSERT INTO ProdutoLimpeza (DataValidade, Nome, Volume, Id_ElementoEstoque)
    VALUES ('2024-09-10', 'Sabão em Pó', 700, 3);
END

-- Inserção na tabela PesquisaMercado
IF NOT EXISTS (SELECT 1 FROM PesquisaMercado WHERE Satisfacao = 85 AND InstitutoPesquisa = 'Instituto A' AND Id_ProdutoLimpeza = 1)
BEGIN
    INSERT INTO PesquisaMercado (Satisfacao, InstitutoPesquisa, Id_ProdutoLimpeza)
    VALUES (85, 'Instituto A', 1);
END

IF NOT EXISTS (SELECT 1 FROM PesquisaMercado WHERE Satisfacao = 56 AND InstitutoPesquisa = 'Instituto B' AND Id_ProdutoLimpeza = 2)
BEGIN
    INSERT INTO PesquisaMercado (Satisfacao, InstitutoPesquisa, Id_ProdutoLimpeza)
    VALUES (56, 'Instituto B', 2);
END

IF NOT EXISTS (SELECT 1 FROM PesquisaMercado WHERE Satisfacao = 90 AND InstitutoPesquisa = 'Instituto C' AND Id_ProdutoLimpeza = 3)
BEGIN
    INSERT INTO PesquisaMercado (Satisfacao, InstitutoPesquisa, Id_ProdutoLimpeza)
    VALUES (90, 'Instituto C', 3);
END

-- Inserção na tabela Alimento
IF NOT EXISTS (SELECT 1 FROM Alimento WHERE DataValidade = '2024-07-15' AND Nome = 'Arroz' AND Id_ElementoEstoque = 4 AND Peso = 1.5)
BEGIN
    INSERT INTO Alimento (DataValidade, Nome, Id_ElementoEstoque, Peso)
    VALUES ('2024-07-15', 'Arroz', 4, 1.5);
END

IF NOT EXISTS (SELECT 1 FROM Alimento WHERE DataValidade = '2024-07-10' AND Nome = 'Feijão' AND Id_ElementoEstoque = 5 AND Peso = 2.0)
BEGIN
    INSERT INTO Alimento (DataValidade, Nome, Id_ElementoEstoque, Peso)
    VALUES ('2024-07-10', 'Feijão', 5, 2.0);
END

IF NOT EXISTS (SELECT 1 FROM Alimento WHERE DataValidade = '2024-06-30' AND Nome = 'Carne' AND Id_ElementoEstoque = 6 AND Peso = 1.8)
BEGIN
    INSERT INTO Alimento (DataValidade, Nome, Id_ElementoEstoque, Peso)
    VALUES ('2024-06-30', 'Carne', 6, 1.8);
END

-- Inserção na tabela Estoque
IF NOT EXISTS (SELECT 1 FROM Estoque WHERE Quantidade = 100 AND Id_ElementoEstoque = 1)
BEGIN
    INSERT INTO Estoque (Quantidade, Id_ElementoEstoque)
    VALUES (100, 1);
END

IF NOT EXISTS (SELECT 1 FROM Estoque WHERE Quantidade = 150 AND Id_ElementoEstoque = 2)
BEGIN
    INSERT INTO Estoque (Quantidade, Id_ElementoEstoque)
    VALUES (150, 2);
END

IF NOT EXISTS (SELECT 1 FROM Estoque WHERE Quantidade = 200 AND Id_ElementoEstoque = 3)
BEGIN
    INSERT INTO Estoque (Quantidade, Id_ElementoEstoque)
    VALUES (200, 3);
END

IF NOT EXISTS (SELECT 1 FROM Estoque WHERE Quantidade = 50 AND Id_ElementoEstoque = 4)
BEGIN
    INSERT INTO Estoque (Quantidade, Id_ElementoEstoque)
    VALUES (50, 4);
END

IF NOT EXISTS (SELECT 1 FROM Estoque WHERE Quantidade = 120 AND Id_ElementoEstoque = 5)
BEGIN
    INSERT INTO Estoque (Quantidade, Id_ElementoEstoque)
    VALUES (120, 5);
END

IF NOT EXISTS (SELECT 1 FROM Estoque WHERE Quantidade = 80 AND Id_ElementoEstoque = 6)
BEGIN
    INSERT INTO Estoque (Quantidade, Id_ElementoEstoque)
    VALUES (80, 6);
END

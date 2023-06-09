CREATE TABLE Evento (
    ID INT PRIMARY KEY,
    ID_organizador INT,
    nome VARCHAR(50),
    data DATE,
    hora TIME,
    local VARCHAR(50),
    descricao TEXT,
    capacidade_max INT,
    preco_ingresso DECIMAL(10,2),
    FOREIGN KEY (ID_organizador) REFERENCES Organizador(ID_utilizador)
);
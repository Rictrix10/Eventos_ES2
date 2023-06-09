CREATE TABLE Tipo_Ingresso (
    ID INT PRIMARY KEY,
    ID_evento INT,
    nome VARCHAR(50),
    quantidade_disponivel INT,
    preco DECIMAL(10,2),
    FOREIGN KEY (ID_evento) REFERENCES Evento(ID)
);
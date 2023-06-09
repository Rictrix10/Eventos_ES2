CREATE TABLE Atividade (
    ID INT PRIMARY KEY,
    ID_evento INT,
    nome VARCHAR(50),
    data DATE,
    hora TIME,
    descricao TEXT,
    FOREIGN KEY (ID_evento) REFERENCES Evento(ID)
);
CREATE TABLE Mensagem (
    ID INT PRIMARY KEY,
    ID_organizador INT,
    ID_evento INT,
    assunto VARCHAR(50),
    corpo TEXT,
    data_envio DATE,
    FOREIGN KEY (ID_organizador) REFERENCES Organizador(ID_utilizador),
    FOREIGN KEY (ID_evento) REFERENCES Evento(ID)
);
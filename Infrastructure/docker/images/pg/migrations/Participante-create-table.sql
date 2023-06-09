CREATE TABLE Participante (
    ID_utilizador INT PRIMARY KEY,
    FOREIGN KEY (ID_utilizador) REFERENCES Utilizador(ID)
);
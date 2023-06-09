CREATE TABLE Organizador (
    ID_utilizador INT PRIMARY KEY,
    FOREIGN KEY (ID_utilizador) REFERENCES Utilizador(ID)
);

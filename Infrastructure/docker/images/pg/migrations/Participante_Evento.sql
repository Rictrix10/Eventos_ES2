CREATE TABLE Participante_Evento (
    ID_participante INT,
    ID_evento INT,
    data_registro DATE,
    PRIMARY KEY (ID_participante, ID_evento),
    FOREIGN KEY (ID_participante) REFERENCES Participante(ID_utilizador),
    FOREIGN KEY (ID_evento) REFERENCES Evento(ID)
);
CREATE TABLE Participante_Atividade (
    ID_participante INT,
    ID_atividade INT,
    PRIMARY KEY (ID_participante, ID_atividade),
    FOREIGN KEY (ID_participante) REFERENCES Participante(ID_utilizador),
    FOREIGN KEY (ID_atividade) REFERENCES Atividade(ID)
);
-- Inserir dados na tabela "public.tipo_utilizador"
INSERT INTO public.tipo_utilizador (tipo)
VALUES ('Organizador'), ('Participante');

-- Inserir dados na tabela "public.autenticacao"
INSERT INTO public.autenticacao (tipo)
VALUES ('User'), ('UserManager'), ('Admin');

-- Inserir dados na tabela "public.utilizador"
INSERT INTO public.utilizador (username, nome, email, password, telefone, id_tipo_utilizador, id_autenticacao)
VALUES ('goncalves10', 'Ricardo Gonçalves', 'goncalves10@gmail.com', 'EventosES2@', '999713269', 1, 3),
       ('cerqueira10', 'Ricardo Cerqueira', 'cerqueira10@gmail.com', 'EngenhariaSoftware2@', '961799923', 2, 1);
       

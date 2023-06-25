-- Inserir tipos de utilizador
INSERT INTO public.tipo_utilizador (tipo) VALUES
                                              ('Organizador'),
                                              ('Participante');

-- Inserir tipos de autenticação
INSERT INTO public.autenticacao (tipo) VALUES
                                           ('Admin'),
                                           ('UserManager'),
                                           ('User');

-- Inserir utilizadores
INSERT INTO public.utilizador (username, nome, email, password, telefone, tipo, autenticacao, id_tipo_utilizador, id_autenticacao) VALUES
                                                                                                                                       ('joaosilva', 'João Silva', 'joao@example.com', 'joao123silva', '923456789', 'Participante', 'User', 2, 3),
                                                                                                                                       ('mariagomes', 'Maria Gomes', 'maria@example.com', 'gomesmaria2', '987654321', 'Organizador', 'User', 1, 2),
                                                                                                                                       ('luisteofilo', 'Luis Teofilo', 'teofilo@example.com', 'teofiloes2', '922494780', 'Admin', 'Admin', 1, 2);

-- Inserir eventos
INSERT INTO public.evento (nome, data, hora, local, descricao, capacidademax, categoria, id_organizador) VALUES
                                                                                                             ('Concerto de Rock', '2023-07-20', '19:30:00', 'Porto', 'Um concerto incrível com bandas de rock famosas.', 1000, 'Música', 2),
                                                                                                             ('Workshop de Programação', '2023-08-10', '14:00:00', 'Lisboa', 'Um workshop para aprender as melhores práticas de programação.', 50, 'Tecnologia', 1);

-- Inserir atividades
INSERT INTO public.atividade (nome, data, hora, descricao, id_evento) VALUES
                                                                          ('Palestra sobre Tecnologia', '2023-08-10', '15:00:00', 'Uma palestra interessante sobre as últimas tendências tecnológicas.', 2),
                                                                          ('Oficina de Guitarra', '2023-07-20', '16:00:00', 'Uma oficina prática para aprender a tocar guitarra.', 1);

-- Inserir inscrições em eventos
INSERT INTO public.inscricao_evento (tipo_ingresso, id_participante, id_evento) VALUES
                                                                                    ('Entrada Normal', 1, 1),
                                                                                    ('Entrada VIP', 1, 2);

-- Inserir mensagens
INSERT INTO public.mensagem (mensagem, id_organizador, id_participante, id_evento) VALUES
                                                                                       ('Olá! O evento está confirmado para a próxima semana. Mal posso esperar para vê-lo lá!', 2, 1, 1),
                                                                                       ('Lembrete: a oficina de guitarra começa em uma hora. Não se atrase!', 2, 1, 1);

-- Inserir feedbacks
INSERT INTO public.feedback (feedback, id_participante, id_evento) VALUES
                                                                       ('O concerto foi incrível. Adorei todas as bandas!', 1, 1),
                                                                       ('O workshop de programação foi muito informativo. Aprendi muito.', 1, 2);

-- Inserir relação entre eventos e tipos de ingresso
INSERT INTO public.evento_ingresso (id_evento, quantidade, preco, tipo_ingresso) VALUES
                                                                                     (1, 500, 20.00, 'Entrada Normal'),
                                                                                     (1, 200, 50.00, 'Entrada VIP');

create table public.tipo_utilizador
(
    id_tipo_utilizador serial
        primary key,
    tipo               varchar(255)
);


create table public.autenticacao
(
    id_autenticacao serial
        primary key,
    tipo            varchar(255)
);


create table public.utilizador
(
    id_utilizador      serial
        primary key,
    username           varchar(255),
    nome               varchar(255),
    email              varchar(255),
    password           varchar(255),
    telefone           varchar(255),
    id_tipo_utilizador integer
        references public.tipo_utilizador,
    id_autenticacao    integer
        references public.autenticacao
);


create table public.evento
(
    id_evento      serial
        primary key,
    nome           varchar(255),
    data           date,
    hora           time,
    local          varchar(255),
    descricao      text,
    capacidademax  integer,
    categoria      varchar(255),
    id_organizador integer
        references public.utilizador
);


create table public.tipo_ingresso
(
    id_tipo_ingresso serial
        primary key,
    nome             varchar(255),
    preco            numeric(10, 2)
);


create table public.atividade
(
    id_atividade serial
        primary key,
    nome         varchar(255),
    data         date,
    hora         time,
    descricao    text,
    id_evento    integer
        references public.evento
);



create table public.inscricao_evento
(
    id_inscricao_evento serial
        primary key,
    id_participante     integer
        references public.utilizador,
    id_evento           integer
        references public.evento
);


create table public.inscricao_atividade
(
    id_inscricao_atividade serial
        primary key,
    id_participante        integer
        references public.utilizador,
    id_atividade           integer
        references public.atividade
);



create table public.mensagem
(
    id_mensagem     serial
        primary key,
    mensagem        text,
    id_organizador  integer
        references public.utilizador,
    id_participante integer
        references public.utilizador,
    id_evento       integer
        references public.evento
);



create table public.feedback
(
    id_feedback     serial
        primary key,
    feedback        text,
    id_participante integer
        references public.utilizador,
    id_evento       integer
        references public.evento
);




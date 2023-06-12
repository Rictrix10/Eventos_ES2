create table public.tipo_utilizador
(
    id   serial
        primary key,
    tipo varchar(20)
        unique
);



create table public.utilizador
(
    id       integer not null
        primary key,
    nome     varchar(50),
    email    varchar(50),
    password varchar(50),
    id_tipo  integer
        references public.tipo_utilizador
);



create table public.organizador
(
    id_utilizador integer not null
        primary key
        references public.utilizador
);



create table public.participante
(
    id_utilizador integer not null
        primary key
        references public.utilizador
);



create table public.evento
(
    id             integer not null
        primary key,
    id_organizador integer
        references public.organizador,
    nome           varchar(50),
    data           date,
    hora           time,
    local          varchar(50),
    descricao      text,
    capacidade_max integer,
    preco_ingresso numeric(10, 2)
);



create table public.tipo_ingresso
(
    id                    integer not null
        primary key,
    id_evento             integer
        references public.evento,
    nome                  varchar(50),
    quantidade_disponivel integer,
    preco                 numeric(10, 2)
);



create table public.atividade
(
    id        integer not null
        primary key,
    id_evento integer
        references public.evento,
    nome      varchar(50),
    data      date,
    hora      time,
    descricao text
);



create table public.participante_evento
(
    id_participante integer not null
        references public.participante,
    id_evento       integer not null
        references public.evento,
    data_registro   date,
    primary key (id_participante, id_evento)
);


create table public.participante_atividade
(
    id_participante integer not null
        references public.participante,
    id_atividade    integer not null
        references public.atividade,
    primary key (id_participante, id_atividade)
);



create table public.mensagem
(
    id             integer not null
        primary key,
    id_organizador integer
        references public.organizador,
    id_evento      integer
        references public.evento,
    assunto        varchar(50),
    corpo          text,
    data_envio     date
);

alter table utilizador
    add idade integer;

create table public.tipo_utilizador
(
    id   serial
        primary key,
    tipo varchar(20)
        unique
);

alter table public.tipo_utilizador
    owner to postgres;

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

alter table public.utilizador
    owner to postgres;

create table public.organizador
(
    id_utilizador integer not null
        primary key
        references public.utilizador
);

alter table public.organizador
    owner to postgres;

create table public.participante
(
    id_utilizador integer not null
        primary key
        references public.utilizador
);

alter table public.participante
    owner to postgres;

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

alter table public.evento
    owner to postgres;

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

alter table public.tipo_ingresso
    owner to postgres;

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

alter table public.atividade
    owner to postgres;

create table public.participante_evento
(
    id_participante integer not null
        references public.participante,
    id_evento       integer not null
        references public.evento,
    data_registro   date,
    primary key (id_participante, id_evento)
);

alter table public.participante_evento
    owner to postgres;

create table public.participante_atividade
(
    id_participante integer not null
        references public.participante,
    id_atividade    integer not null
        references public.atividade,
    primary key (id_participante, id_atividade)
);

alter table public.participante_atividade
    owner to postgres;

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

alter table public.mensagem
    owner to postgres;

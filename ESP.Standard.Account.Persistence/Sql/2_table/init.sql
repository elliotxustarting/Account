CREATE TABLE public.account
(
    id bigint NOT NULL DEFAULT nextval('account_id_seq'::regclass),
    username character varying(50) COLLATE pg_catalog."default" NOT NULL,
    password character varying(50) COLLATE pg_catalog."default" NOT NULL,
    createdby bigint,
    createdtime timestamp with time zone,
    updatedby bigint,
    updatedtime timestamp with time zone,
    CONSTRAINT account_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.account
    OWNER to postgres;



CREATE TABLE public.menu
(
    id integer NOT NULL DEFAULT nextval('menu_id_seq'::regclass),
    tenantid integer NOT NULL,
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    description character varying(200) COLLATE pg_catalog."default",
    createdby bigint,
    createdtime timestamp with time zone,
    updatedby bigint,
    updatedtime timestamp with time zone,
    CONSTRAINT menu_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.menu
    OWNER to postgres;



CREATE TABLE public.organization
(
    id bigint NOT NULL DEFAULT nextval('organization_id_seq'::regclass),
    tenantid integer NOT NULL,
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    description character varying(200) COLLATE pg_catalog."default",
    parentid bigint,
    createdby bigint,
    createdtime timestamp with time zone,
    updatedby bigint,
    updatedtime timestamp with time zone,
    CONSTRAINT organization_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.organization
    OWNER to postgres;



CREATE TABLE public.permission
(
    id integer NOT NULL DEFAULT nextval('permission_id_seq'::regclass),
    tenantid integer NOT NULL,
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    description character varying(200) COLLATE pg_catalog."default",
    createdby bigint,
    createdtime timestamp with time zone,
    updatedby bigint,
    updatedtime timestamp with time zone,
    CONSTRAINT permission_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.permission
    OWNER to postgres;



CREATE TABLE public.role
(
    id integer NOT NULL DEFAULT nextval('role_id_seq'::regclass),
    tenantid integer NOT NULL,
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    description character varying(200) COLLATE pg_catalog."default",
    createdby bigint,
    createdtime timestamp with time zone,
    updatedby bigint,
    updatedtime timestamp with time zone,
    CONSTRAINT role_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.role
    OWNER to postgres;



CREATE TABLE public."user"
(
    id bigint NOT NULL DEFAULT nextval('user_id_seq'::regclass),
    tenantid integer NOT NULL,
    realname character varying(50) COLLATE pg_catalog."default" NOT NULL,
    email character varying(50) COLLATE pg_catalog."default",
    mobile character varying(20) COLLATE pg_catalog."default",
    qq character varying(20) COLLATE pg_catalog."default",
    wechat character varying(50) COLLATE pg_catalog."default",
    createdby bigint,
    createdtime timestamp with time zone,
    updatedby bigint,
    updatedtime timestamp with time zone,
    CONSTRAINT user_pkey PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."user"
    OWNER to postgres;



CREATE TABLE public.rel_user_account
(
    userid bigint NOT NULL,
    accountid bigint NOT NULL,
    CONSTRAINT rel_user_account_pkey PRIMARY KEY (userid, accountid)
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.rel_user_account
    OWNER to postgres;
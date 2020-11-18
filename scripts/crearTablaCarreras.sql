CREATE TABLE public.carreras
(
	nombrecarrera character varying(50) NOT NULL,
	costo numeric NOT NULL,
	ruta bytea NULL,
	tipoactividad numeric REFERENCES tiposactividades(idact),
	privacidad character varying(50),
	fecha character varying(50) NOT NULL,
	cuentapago numeric NOT NULL,
	CONSTRAINT carreras_pkey PRIMARY KEY (nombrecarrera)
);

CREATE TABLE public.retos
(
	nombrereto character varying(50) NOT NULL,
	periodo_inicio DATE NOT NULL,
	periodo_final DATE NOT NULL,
	tiporeto numeric REFERENCES tiposactividades(idact),
	privacidad character varying(50),
	CONSTRAINT retos_pkey PRIMARY KEY (nombrereto)
);

CREATE TABLE public.patrocinadoresporcarrera(
	idelemento character varying(50) NOT NULL,
	nombrecarrerafk  character varying(50) REFERENCES carreras(nombrecarrera),
	patrocinador integer REFERENCES patrocinadores(idpat),
	CONSTRAINT patrocinadoresporcarrera_pkey PRIMARY KEY (idelemento)
);

CREATE TABLE public.categoriasporcarrera(
	idelemento character varying(50),
	nombrecarrerafk  character varying(50) REFERENCES carreras(nombrecarrera),
	categoria integer REFERENCES categorias(idcat),
	CONSTRAINT categoriasporcarrera_pkey PRIMARY KEY (idelemento)
);

CREATE TABLE public.categorias
(
	idcat numeric NOT NULL,
	nombre character varying(500) NOT NULL,
	rango character varying(100) NOT NULL,
	CONSTRAINT categorias_pkey PRIMARY KEY (idcat)
);

CREATE TABLE public.patrocinadores
(
	idpat numeric NOT NULL,
	nombre character varying(500) NOT NULL,
	representante character varying(100) NOT NULL,
	telefono numeric NOT NULL,
	logo bytea NULL,
	CONSTRAINT patrocinadores_pkey PRIMARY KEY (idpat)
);

CREATE TABLE public.tiposactividades
(
	idact numeric NOT NULL,
	nombre character varying(500) NOT NULL,
	CONSTRAINT tiposactividades_pkey PRIMARY KEY (idact)
);

INSERT INTO public."categorias"("idcat","nombre","rango")
VALUES (1,'Junior','menos de 15 años');
INSERT INTO public."categorias"("idcat","nombre","rango")
VALUES (2,'Sub-23','de 15 a 23');
INSERT INTO public."categorias"("idcat","nombre","rango")
VALUES (3,'Open',' de 24 a 30 años');
INSERT INTO public."categorias"("idcat","nombre","rango")
VALUES (4,'Elite','cualquiera que quiera inscribirse');
INSERT INTO public."categorias"("idcat","nombre","rango")
VALUES (5,'Master A','de 30 a 40 años');
INSERT INTO public."categorias"("idcat","nombre","rango")
VALUES (6,'Master B','de 41 a 50 años');
INSERT INTO public."categorias"("idcat","nombre","rango")
VALUES (7,'Master C','más de 51 años');

INSERT INTO public."patrocinadores"("idpat","nombre","representante","telefono")
VALUES (1,'CocaCola','elosodecocacola',12345678);
INSERT INTO public."patrocinadores"("idpat","nombre","representante","telefono")
VALUES (2,'Kolbi','albino',2000000);

SELECT * FROM public."patrocinadores"

INSERT INTO public."tiposactividades"("idact","nombre")
VALUES (1,'Correr');
INSERT INTO public."tiposactividades"("idact","nombre")
VALUES (2,'Nadar');
INSERT INTO public."tiposactividades"("idact","nombre")
VALUES (3,'Ciclismo');
INSERT INTO public."tiposactividades"("idact","nombre")
VALUES (4,'Senderismo');
INSERT INTO public."tiposactividades"("idact","nombre")
VALUES (5,'Kayak');
INSERT INTO public."tiposactividades"("idact","nombre")
VALUES (6,'Caminata');

SELECT * FROM public."tiposactividades"


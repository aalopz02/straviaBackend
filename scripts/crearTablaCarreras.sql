CREATE TABLE public.carreras
(
	NombreCarrera character varying(50) NOT NULL,
	Costo numeric NOT NULL,
	Ruta character varying(500) NOT NULL,
	Tipo character varying(50) NOT NULL,
	Fecha character varying(50) NOT NULL,
	CuentaPago numeric NOT NULL,
	CONSTRAINT carrera_pkey PRIMARY KEY (NombreCarrera)
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
	--logo bytea NOT NULL,
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


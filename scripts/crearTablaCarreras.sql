CREATE TABLE public.carreras////asdcasdc LA DE USUARIO UN ATRIBUTO NULL CHAR VARYING 50 imagenperfil
(
	nombrecarrera character varying(50) NOT NULL,
	costo numeric NOT NULL,
	dirruta character varying(50) NULL,
	tipoactividad numeric REFERENCES tiposactividades(idact),
	privacidad character varying(50),
	fecha DATE NOT NULL,
	cuentapago numeric NOT NULL
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
	dirlogo character varying(50) NULL,
	CONSTRAINT patrocinadores_pkey PRIMARY KEY (idpat)
);

CREATE TABLE public.tiposactividades
(
	idact numeric NOT NULL,
	nombre character varying(500) NOT NULL,
	CONSTRAINT tiposactividades_pkey PRIMARY KEY (idact)
);

CREATE TABLE public.seguidores
(
	idelemento character varying(50) NOT NULL,
	nombreusuariofk character varying(50) NOT NULL REFERENCES usuario(nombreusuario),
	nombreusuariosiguiendofk character varying(50) NOT NULL REFERENCES usuario(nombreusuario),
	CONSTRAINT idelemento_pkey PRIMARY KEY (idelemento)
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

VALUES ('adrian03','clave2','adrian','lopez','Vásquez','03-09-1998','cr',0,0);
INSERT INTO public."usuario"( nombreusuario, "contraseña", fname, mname, lname, fechanacimiento, nacionalidad, nsiguiendo, nseguidores)
VALUES ('ldnoguera','clave3','luis','noguera','mena','20-08-1998','cr',0,0);
INSERT INTO public."usuario"( nombreusuario, "contraseña", fname, mname, lname, fechanacimiento, nacionalidad, nsiguiendo, nseguidores)
VALUES ('albino','clave4','albino','ice','aya','12-12-2012','cr',0,0);
INSERT INTO public."usuario"( nombreusuario, "contraseña", fname, mname, lname, fechanacimiento, nacionalidad, nsiguiendo, nseguidores)
VALUES ('charlie','clave5','carlos','alvarado','segundoapellido','20-08-1920','cr',0,0);
INSERT INTO public."usuario"( nombreusuario, "contraseña", fname, mname, lname, fechanacimiento, nacionalidad, nsiguiendo, nseguidores)
VALUES ('gerald02','clave5','gerald','salazar','elizondo','20-08-1998','cr',0,0);
INSERT INTO public."usuario"( nombreusuario, "contraseña", fname, mname, lname, fechanacimiento, nacionalidad, nsiguiendo, nseguidores)
VALUES ('kevin98','clave6','kevin','alanis','Pineda','20-08-1998','cr',0,0);

SELECT nombreusuario, "contraseña", fname, mname, lname, fechanacimiento, nacionalidad, nsiguiendo, nseguidores
	FROM public.usuario;

CREATE TABLE public.actividad
(
	idactividad character varying(100) NOT NULL,
	nombreusuariofk character varying(50) REFERENCES usuario(nombreusuario) NOT NULL,
	fecha DATE NOT NULL,
	duracionmin numeric NOT NULL,
	tipoactividad numeric REFERENCES tiposactividades(idact) NOT NULL,
	distanciakm numeric NOT NULL,
	dirrecorrido character varying(50) NULL,
	carreraoreto character varying(50) NULL,
	CONSTRAINT idactividad_pkey PRIMARY KEY (idactividad)
);

CREATE TABLE public.actividad
(
	nombreusuario character varying(50) NOT NULL,
	contraseña character varying(500)  NOT NULL,
	fname character varying(50) NOT NULL,
	mnane character varying(50) NOT NULL,
	lname character varying(50) NOT NULL,
	fecha character varying(50) NOT NULL,
	nacionalidad character varying(50) NULL,
	nsiguiendo numeric NOT NULL,
	nseguidores numeric NOT NULL,
	imagenperfil character varying(50) NOT NULL,
	CONSTRAINT nombreusuario_pkey PRIMARY KEY (nombreusuario)
);
	
INSERT INTO public.actividad(
	idactividad, nombreusuariofk, fecha, duracionmin, tipoactividad, distanciakm, carreraoreto, dirrecorrido)
	VALUES ('ldnoguera2020-11-12', 'ldnoguera', '2020-11-12', 12, 1, 12, 'carrera', 'ldnoguera2020-11-12.gpx');
INSERT INTO public.actividad(
	idactividad, nombreusuariofk, fecha, duracionmin, tipoactividad, distanciakm, carreraoreto, dirrecorrido)
	VALUES ('ldnoguera2020-11-10', 'ldnoguera', '2020-11-10', 10, 2, 14, 'carrera', 'ldnoguera2020-11-10.gpx');
INSERT INTO public.actividad(
	idactividad, nombreusuariofk, fecha, duracionmin, tipoactividad, distanciakm, carreraoreto, dirrecorrido)
	VALUES ('adrian032020-11-01', 'adrian03', '2020-11-01', 11, 1, 44, 'carrera', 'adrian032020-11-01.gpx');


CREATE TABLE public.inscripcioncarreras
(
	nombrecarrera character varying(50) NOT NULL REFERENCES carreras(nombrecarrera),
	nombreusuario character varying(50) NOT NULL REFERENCES usuario(nombreusuario),
	recibo character varying(50) NULL,
	idinscar character varying(50),
	CONSTRAINT inscripcioncarreras_pkey PRIMARY KEY (idinscar)
);

CREATE TABLE public.inscripcionretos
(
	nombrecarrera character varying(50) NOT NULL REFERENCES carreras(nombrecarrera),
	nombreusuario character varying(50) NOT NULL REFERENCES usuario(nombreusuario),
	idinsret character varying(50),
	CONSTRAINT inscripcionretos_pkey PRIMARY KEY (idinsret)
);
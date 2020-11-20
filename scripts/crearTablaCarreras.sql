CREATE TABLE public.carreras
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
	tipoact numeric REFERENCES tiposactividades(idact),
	tipo character varying(7),
	privacidad character varying(50),
	CONSTRAINT retos_pkey PRIMARY KEY (nombrereto)
);

CREATE TABLE public.grupos
(
	nombregrupo character varying(50) NOT NULL,
	nombreusuario character varying(50) NOT NULL REFERENCES usuario(nombreusuario),
	idgrupo character varying(100) NOT NULL,
	CONSTRAINT grupos_pkey PRIMARY KEY (idgrupo)
);


CREATE TABLE public.inscripcionescarrera
(
	nombrecarrera character varying(50) NOT NULL REFERENCES carreras(nombrecarrera),
	nombreusuario character varying(50) NOT NULL REFERENCES usuario(nombreusuario),
	idinscar character varying(100) NOT NULL,
	CONSTRAINT inscripcionescarrera_pkey PRIMARY KEY (idinscar)
);



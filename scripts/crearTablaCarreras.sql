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

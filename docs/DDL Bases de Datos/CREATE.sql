CREATE TABLE JAGLUGAR(
     id SERIAL,
     nombre VARCHAR (50) NOT NULL,
     tipo VARCHAR (50) NOT NULL,
     LUGAR_id INTEGER,

     CONSTRAINT LUGAR_PK PRIMARY KEY (id),

     CONSTRAINT LUGAR_LUGAR_FK FOREIGN KEY( LUGAR_id ) REFERENCES JAGLUGAR( id ),

     CONSTRAINT LUGAR_CH CHECK ( tipo IN ('Direccion', 'Ciudad', 'Estado', 'Pais') )
);


CREATE TABLE JAGINTERES(
     id SERIAL,
     nombre VARCHAR (50) NOT NULL,
     descripcion VARCHAR (100) NOT NULL,

     CONSTRAINT INTERES_PK PRIMARY KEY  (id)
);


CREATE TABLE JAGCLUB(
     id SERIAL,
     fecha_fundacion DATE NOT NULL,
     telefono NUMERIC(15) NOT NULL,
     pagina_web VARCHAR (50),
     proposito VARCHAR (100),
     LUGAR_id INTEGER NOT NULL,
     nombre VARCHAR (50) NOT NULL,

     CONSTRAINT CLUB_PK PRIMARY KEY (id),
     CONSTRAINT CLUB_LUGAR_FK FOREIGN KEY( LUGAR_id ) REFERENCES JAGLUGAR( id )
);


CREATE TABLE JAGCLU_INT(
     INTERES_id INTEGER NOT NULL,
     CLUB_id INTEGER NOT NULL,

     CONSTRAINT CLU_INT_PK PRIMARY KEY  (INTERES_id, CLUB_id),

     CONSTRAINT CLU_INT_CLUB_FK FOREIGN KEY( CLUB_id ) REFERENCES JAGCLUB( id ) ,
     CONSTRAINT CLU_INT_INTERES_FK FOREIGN KEY( INTERES_id ) REFERENCES JAGINTERES( id )
);


CREATE TABLE JAGREPRESENTANTE(
     documento_identidad NUMERIC(10) NOT NULL,
     nombre VARCHAR (25) NOT NULL,
     apellido VARCHAR (25) NOT NULL,
     fecha_nacimiento DATE NOT NULL,

     CONSTRAINT REPRESENTANTE_PK PRIMARY KEY  (documento_identidad) 
);


CREATE TABLE JAGCOLECCIONISTA(
     documento_identidad NUMERIC(10) NOT NULL,
     primer_nombre VARCHAR (50) NOT NULL,
     segundo_nombre VARCHAR (50),
     primer_apellido VARCHAR (50) NOT NULL,
     segundo_apellido VARCHAR (50),
     telefono NUMERIC(15) NOT NULL,
     fecha_nacimiento DATE NOT NULL,
     LUGAR_id_nacionalidad INTEGER NOT NULL,
     COLECCIONISTA_documento_identidad INTEGER,
     REPRESENTANTE_documento_identidad INTEGER,
     LUGAR_id_direccion INTEGER NOT NULL,

     CONSTRAINT COLECCIONISTA_PK PRIMARY KEY (documento_identidad),

     CONSTRAINT COLECCIONISTA_COLECCIONISTA_FK FOREIGN KEY( COLECCIONISTA_documento_identidad ) REFERENCES JAGCOLECCIONISTA( documento_identidad ),
     CONSTRAINT COLECCIONISTA_LUGAR_FK FOREIGN KEY( LUGAR_id_direccion ) REFERENCES JAGLUGAR( id ),
     CONSTRAINT COLECCIONISTA_LUGAR_FKv2 FOREIGN KEY( LUGAR_id_nacionalidad ) REFERENCES JAGLUGAR( id ),
     CONSTRAINT COLECCIONISTA_REPRESENTANTE_FK FOREIGN KEY( REPRESENTANTE_documento_identidad ) REFERENCES JAGREPRESENTANTE( documento_identidad ) ,

     CONSTRAINT COLECCIONISTA_AR CHECK (( ( representante_documento_identidad IS NOT NULL ) AND ( coleccionista_documento_identidad IS NULL ) )
                                      OR( ( coleccionista_documento_identidad IS NOT NULL ) AND ( representante_documento_identidad IS NULL ) )
                                          OR( ( representante_documento_identidad IS NULL ) AND ( coleccionista_documento_identidad IS NULL ) ) )


);


CREATE TABLE JAGCONTACTO(
     id SERIAL,
     usuario_email VARCHAR (50),
     telefono NUMERIC(15),
     plataforma VARCHAR (50) NOT NULL,
     CLUB_id INTEGER NOT NULL,

     CONSTRAINT CONTACTO_PK PRIMARY KEY  (CLUB_id, id),
     CONSTRAINT CONTACTO_CLUB_FK FOREIGN KEY( CLUB_id ) REFERENCES JAGCLUB( id )
);


CREATE TABLE JAGCOLECCIONABLE(
     id SERIAL,
     nombre VARCHAR (50) NOT NULL,
     descripcion_detallada VARCHAR (100) NOT NULL,

     CONSTRAINT COLECCIONABLE_PK PRIMARY KEY  (id)
);


CREATE TABLE JAGCOMIC(
     id SERIAL,
     titulo VARCHAR (50) NOT NULL,
     volumen NUMERIC(10),
     numero NUMERIC(10) NOT NULL,
     fecha_publicacion DATE NOT NULL,
     precio_publicacion REAL,
     color BOOLEAN NOT NULL,
     sinopsis VARCHAR (1000) NOT NULL,
     paginas NUMERIC(10) NOT NULL,
     cubierta BOOLEAN NOT NULL,
     editor VARCHAR (50) NOT NULL,

     CONSTRAINT COMIC_PK PRIMARY KEY  (id)
);


CREATE TABLE JAGDUENO_HISTORICO(
     id SERIAL,
     fecha_registro DATE NOT NULL,
     significado VARCHAR (50),
     COLECCIONISTA_documento_identidad NUMERIC(10) NOT NULL,
     COLECCIONABLE_id INTEGER,
     precio_dolar REAL,
     COMIC_id INTEGER,

     CONSTRAINT DUENO_HISTORICO_PK PRIMARY KEY  (COLECCIONISTA_documento_identidad, fecha_registro, id),

     CONSTRAINT DUENO_HISTORICO_COLECCIONABLE_FK FOREIGN KEY( COLECCIONABLE_id ) REFERENCES JAGCOLECCIONABLE( id ),
     CONSTRAINT DUENO_HISTORICO_COLECCIONISTA_FK FOREIGN KEY( COLECCIONISTA_documento_identidad ) REFERENCES JAGCOLECCIONISTA( documento_identidad ),
     CONSTRAINT DUENO_HISTORICO_COMIC_FK FOREIGN KEY( COMIC_id ) REFERENCES JAGCOMIC( id ),

     CONSTRAINT DUENO_HISTORICO_AR CHECK ( (  (COMIC_id IS NOT NULL) AND (COLECCIONABLE_id IS NULL) )
                                OR (  (COLECCIONABLE_id IS NOT NULL) AND (COMIC_id IS NULL) ))

);


CREATE TABLE JAGLOCAL(
     id SERIAL,
     nombre VARCHAR (50) NOT NULL,
     LUGAR_id INTEGER NOT NULL,
     COLECCIONISTA_documento_identidad INTEGER,
     tipo VARCHAR (50) NOT NULL,

     CONSTRAINT LOCAL_PK PRIMARY KEY  (id),

     CONSTRAINT LOCAL_COLECCIONISTA_FK FOREIGN KEY( COLECCIONISTA_documento_identidad ) REFERENCES JAGCOLECCIONISTA( documento_identidad ),
     CONSTRAINT LOCAL_LUGAR_FK FOREIGN KEY( LUGAR_id ) REFERENCES JAGLUGAR( id ),

     CONSTRAINT LOCAL_CH CHECK ( tipo IN ('Alquilado', 'De un Miembro') )
);


CREATE TABLE JAGMEMBRESIA(
     fecha_ingreso DATE NOT NULL,
     fecha_retiro DATE,
     CLUB_id INTEGER NOT NULL,
     CLUB_id_lider INTEGER,
     COLECCIONISTA_documento_identidad NUMERIC(10) NOT NULL,
     email_contacto VARCHAR (50),

     CONSTRAINT MEMBRESIA_PK PRIMARY KEY (COLECCIONISTA_documento_identidad, CLUB_id, fecha_ingreso),

     CONSTRAINT MEMBRESIA_CLUB_FK FOREIGN KEY( CLUB_id ) REFERENCES JAGCLUB( id ) ,
     CONSTRAINT MEMBRESIA_CLUB_FK_LIDER FOREIGN KEY( CLUB_id_lider ) REFERENCES JAGCLUB( id ),
     CONSTRAINT MEMBRESIA_COLECCIONISTA_FK FOREIGN KEY( COLECCIONISTA_documento_identidad ) REFERENCES JAGCOLECCIONISTA( documento_identidad )
);


CREATE TABLE JAGORGANIZACION_CARIDAD(
     id SERIAL,
     nombre VARCHAR (50) NOT NULL,
     mision VARCHAR (50) NOT NULL,

     CONSTRAINT ORGANIZACION_CARIDAD_PK PRIMARY KEY (id)
);


CREATE TABLE JAGSUBASTA(
     id SERIAL,
     fecha DATE NOT NULL,
     hora_inicio TIME NOT NULL,
     hora_cierre TIME NOT NULL,
     tipo VARCHAR (50) NOT NULL,
     caridad BOOLEAN NOT NULL,
     cancelado BOOLEAN NOT NULL,
     LOCAL_id INTEGER,
     cerrado BOOLEAN NOT NULL,

     CONSTRAINT SUBASTA_PK PRIMARY KEY  (id),
     CONSTRAINT SUBASTA_CH CHECK ( tipo IN ('Presencial', 'Virtual') ),

     CONSTRAINT SUBASTA_LOCAL_FK FOREIGN KEY( LOCAL_id ) REFERENCES JAGLOCAL(id)
     
);


CREATE TABLE JAGPARTICIPANTE(
     id_inscripcion INTEGER NOT NULL,
     SUBASTA_id INTEGER NOT NULL,
     MEMBRESIA_COLECCIONISTA_documento_identidad NUMERIC(10) NOT NULL,
     MEMBRESIA_CLUB_id INTEGER NOT NULL,
     MEMBRESIA_fecha_ingreso DATE NOT NULL,
     autorizado BOOLEAN,

     CONSTRAINT PARTICIPANTE_PK PRIMARY KEY (SUBASTA_id, id_inscripcion),

     CONSTRAINT PARTICIPANTE_MEMBRESIA_FK FOREIGN KEY( MEMBRESIA_COLECCIONISTA_documento_identidad, MEMBRESIA_CLUB_id, MEMBRESIA_fecha_ingreso ) REFERENCES JAGMEMBRESIA( COLECCIONISTA_documento_identidad, CLUB_id, fecha_ingreso ),
     CONSTRAINT PARTICIPANTE_SUBASTA_FK FOREIGN KEY( SUBASTA_id ) REFERENCES JAGSUBASTA( id ) 
);


CREATE TABLE JAGORG_INV(
     id SERIAL,
     SUBASTA_id INTEGER NOT NULL,
     CLUB_id_org INTEGER,
     CLUB_id_inv INTEGER,

     CONSTRAINT ORG_INV_PK PRIMARY KEY  (id, SUBASTA_id),

     CONSTRAINT ORG_INV_CLUB_FK FOREIGN KEY( CLUB_id_org ) REFERENCES JAGCLUB( id ) ,
     CONSTRAINT ORG_INV_CLUB_FKv2 FOREIGN KEY( CLUB_id_inv ) REFERENCES JAGCLUB( id ) ,
     CONSTRAINT ORG_INV_SUBASTA_FK FOREIGN KEY( SUBASTA_id ) REFERENCES JAGSUBASTA( id )  ,

     CONSTRAINT ORG_INV_AR CHECK ( (  (CLUB_id_org IS NOT NULL) AND (CLUB_id_inv IS NULL) )
                                OR(  (CLUB_id_inv IS NOT NULL) AND (CLUB_id_org IS NULL) ) )

);


CREATE TABLE JAGORG_SUB(
     porcentaje NUMERIC(10) NOT NULL,
     monto_recibido REAL,
     ORGANIZACION_CARIDAD_id INTEGER NOT NULL,
     SUBASTA_id INTEGER NOT NULL,

     CONSTRAINT ORG_SUB_PK PRIMARY KEY  (ORGANIZACION_CARIDAD_id, SUBASTA_id),

     CONSTRAINT ORG_SUB_ORGANIZACION_CARIDAD_FK FOREIGN KEY( ORGANIZACION_CARIDAD_id ) REFERENCES JAGORGANIZACION_CARIDAD( id ),
     CONSTRAINT ORG_SUB_SUBASTA_FK FOREIGN KEY( SUBASTA_id ) REFERENCES JAGSUBASTA( id ) 
);


CREATE TABLE JAGLISTADO(
     id SERIAL,
     orden NUMERIC(10),
     precio_base_dolar REAL NOT NULL,
     precio_vendido_dolar REAL,
     SUBASTA_id INTEGER NOT NULL,
     DUENO_HISTORICO_COLECCIONISTA_documento_identidad NUMERIC(10) NOT NULL,
     DUENO_HISTORICO_fecha_registro DATE NOT NULL,
     PARTICIPANTE_subasta_id INTEGER,
     DUENO_HISTORICO_id INTEGER NOT NULL,
     PARTICIPANTE_id_inscripcion INTEGER,
     duracion_min INTEGER,

     CONSTRAINT LISTADO_PK PRIMARY KEY  (SUBASTA_id, id),

     CONSTRAINT LISTADO_DUENO_HISTORICO_FK FOREIGN KEY( DUENO_HISTORICO_COLECCIONISTA_documento_identidad, DUENO_HISTORICO_fecha_registro, DUENO_HISTORICO_id ) REFERENCES JAGDUENO_HISTORICO( COLECCIONISTA_documento_identidad, fecha_registro, id ),
     CONSTRAINT LISTADO_PARTICIPANTE_FK FOREIGN KEY( PARTICIPANTE_subasta_id, PARTICIPANTE_id_inscripcion ) REFERENCES JAGPARTICIPANTE( SUBASTA_id, id_inscripcion ),
     CONSTRAINT LISTADO_SUBASTA_FK FOREIGN KEY( SUBASTA_id ) REFERENCES JAGSUBASTA( id ) 
);

CREATE INDEX index_LUGAR_LUGAR_FK ON JAGlugar( LUGAR_id );

CREATE INDEX index_CLUB_LUGAR_FK ON JAGclub( LUGAR_id );

CREATE INDEX index_CLU_INT_CLUB_FK ON JAGclu_int( CLUB_id );
CREATE INDEX index_CLU_INT_INTERES_FK ON JAGclu_int( INTERES_id );

CREATE INDEX index_COLECCIONISTA_COLECCIONISTA_FK ON JAGcoleccionista( COLECCIONISTA_documento_identidad );
CREATE INDEX index_COLECCIONISTA_LUGAR_FK ON JAGcoleccionista( LUGAR_id_direccion );
CREATE INDEX index_COLECCIONISTA_LUGAR_FKv2 ON JAGcoleccionista( LUGAR_id_nacionalidad );
CREATE INDEX index_COLECCIONISTA_REPRESENTANTE_FK ON JAGcoleccionista( REPRESENTANTE_documento_identidad );

CREATE INDEX index_CONTACTO_CLUB_FK ON JAGcontacto( CLUB_id );

CREATE INDEX index_DUENO_HISTORICO_COLECCIONABLE_FK ON JAGdueno_historico( COLECCIONABLE_id );
CREATE INDEX index_DUENO_HISTORICO_COLECCIONISTA_FK ON JAGdueno_historico( COLECCIONISTA_documento_identidad );
CREATE INDEX index_DUENO_HISTORICO_COMIC_FK ON JAGdueno_historico( COMIC_id );

CREATE INDEX index_LOCAL_COLECCIONISTA_FK ON JAGlocal( COLECCIONISTA_documento_identidad ) ;
CREATE INDEX index_LOCAL_LUGAR_FK ON JAGlocal( LUGAR_id );

CREATE INDEX index_MEMBRESIA_CLUB_FK ON JAGmembresia( CLUB_id );
CREATE INDEX index_MEMBRESIA_CLUB_FK_LIDER ON JAGmembresia( CLUB_id_lider );
CREATE INDEX index_MEMBRESIA_COLECCIONISTA_FK ON JAGmembresia( COLECCIONISTA_documento_identidad );

CREATE INDEX index_SUBASTA_LOCAL_FK ON JAGsubasta( LOCAL_id );

CREATE INDEX index_PARTICIPANTE_MEMBRESIA_FK ON JAGparticipante( MEMBRESIA_COLECCIONISTA_documento_identidad, MEMBRESIA_CLUB_id, MEMBRESIA_fecha_ingreso );
CREATE INDEX index_PARTICIPANTE_SUBASTA_FK ON JAGparticipante( SUBASTA_id );

CREATE INDEX index_ORG_INV_CLUB_FK ON JAGorg_inv( CLUB_id_org );
CREATE INDEX index_ORG_INV_CLUB_FKv2 ON JAGorg_inv( CLUB_id_inv );
CREATE INDEX index_ORG_INV_SUBASTA_FK ON JAGorg_inv( SUBASTA_id );

CREATE INDEX index_ORG_SUB_ORGANIZACION_CARIDAD_FK ON JAGorg_sub( ORGANIZACION_CARIDAD_id );
CREATE INDEX index_ORG_SUB_SUBASTA_FK ON JAGorg_sub( SUBASTA_id );

CREATE INDEX index_LISTADO_DUENO_HISTORICO_FK ON JAGlistado( DUENO_HISTORICO_COLECCIONISTA_documento_identidad, DUENO_HISTORICO_fecha_registro, DUENO_HISTORICO_id );
CREATE INDEX index_LISTADO_PARTICIPANTE_FK ON JAGlistado( PARTICIPANTE_subasta_id, PARTICIPANTE_id_inscripcion );
CREATE INDEX index_LISTADO_SUBASTA_FK ON JAGlistado( SUBASTA_id );

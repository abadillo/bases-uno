-- Generated by Oracle SQL Developer Data Modeler 21.1.0.092.1221
--   at:        2021-06-23 14:14:17 VET
--   site:      SQL Server 2012
--   type:      SQL Server 2012



CREATE TABLE CLU_INT 
    (
     INTERES_id INTEGER NOT NULL , 
     CLUB_id INTEGER NOT NULL 
    )
;

ALTER TABLE CLU_INT ADD CONSTRAINT CLU_INT_PK PRIMARY KEY  (INTERES_id, CLUB_id)
;

CREATE TABLE CLUB 
    (
     id SERIAL , 
     fecha_fundacion DATE NOT NULL , 
     telefono INTEGER NOT NULL , 
     pagina_web VARCHAR (50) , 
     proposito VARCHAR (50) , 
     MEMBRESIA_COLECCIONISTA_documento_identidad INTEGER NOT NULL , 
     MEMBRESIA_CLUB_id INTEGER NOT NULL , 
     MEMBRESIA_fecha_ingreso DATE NOT NULL , 
     LUGAR_id INTEGER NOT NULL 
    )
; 

    


CREATE UNIQUE INDEX 
    CLUB__IDX ON CLUB 
    ( 
     MEMBRESIA_COLECCIONISTA_documento_identidad , 
     MEMBRESIA_CLUB_id , 
     MEMBRESIA_fecha_ingreso 
    ) 
;

ALTER TABLE CLUB ADD CONSTRAINT CLUB_PK PRIMARY KEY  (id)
;

CREATE TABLE COLECCIONABLE 
    (
     id SERIAL , 
     nombre VARCHAR (50) NOT NULL , 
     descripcion_detallada VARCHAR (100) NOT NULL 
    )
;

ALTER TABLE COLECCIONABLE ADD CONSTRAINT COLECCIONABLE_PK PRIMARY KEY  (id)
;

CREATE TABLE COLECCIONISTA 
    (
     documento_identidad INTEGER NOT NULL , 
     primer_nombre VARCHAR (50) NOT NULL , 
     segundo_nombre VARCHAR (50) , 
     primer_apellido VARCHAR (50) NOT NULL , 
     segundo_apellido VARCHAR (50) , 
     telefono INTEGER NOT NULL , 
     fecha_nacimiento DATE NOT NULL , 
     LUGAR_id2 INTEGER NOT NULL , 
     COLECCIONISTA_documento_identidad INTEGER , 
     REPRESENTANTE_documento_identidad INTEGER , 
     LUGAR_id INTEGER NOT NULL 
    )
;

ALTER TABLE COLECCIONISTA ADD CONSTRAINT COLECCIONISTA_PK PRIMARY KEY  (documento_identidad)
;

ALTER TABLE coleccionista ADD CONSTRAINT arc_3 CHECK ( 
    ( ( representante_documento_identidad IS NOT NULL ) AND ( coleccionista_documento_identidad IS NULL ) )
    OR 
    ( ( coleccionista_documento_identidad IS NOT NULL ) AND ( representante_documento_identidad IS NULL ) )
    OR 
    ( ( representante_documento_identidad IS NULL ) AND ( coleccionista_documento_identidad IS NULL ) ) 
    )
;

CREATE TABLE COMIC 
    (
     id SERIAL , 
     titulo VARCHAR (50) NOT NULL , 
     volumen INTEGER , 
     numero INTEGER NOT NULL , 
     fecha_publicacion DATE NOT NULL , 
     precio_publicacion REAL , 
     color BOOLEAN NOT NULL , 
     sinopsis VARCHAR (1000) NOT NULL , 
     paginas INTEGER NOT NULL , 
     cubierta BOOLEAN NOT NULL , 
     editor VARCHAR (50) NOT NULL 
    )
;

ALTER TABLE COMIC ADD CONSTRAINT COMIC_PK PRIMARY KEY  (id)
;

CREATE TABLE CONTACTO 
    (
     id SERIAL , 
     usuario_email VARCHAR (50) , 
     telefono INTEGER , 
     plataforma VARCHAR (50) NOT NULL , 
     CLUB_id INTEGER NOT NULL 
    )
;

ALTER TABLE CONTACTO ADD CONSTRAINT CONTACTO_PK PRIMARY KEY  (CLUB_id, id)
;

CREATE TABLE DUENO_HISTORICO 
    (
     id SERIAL , 
     fecha_registro DATE NOT NULL , 
     significado VARCHAR (50) , 
     COLECCIONISTA_documento_identidad INTEGER NOT NULL , 
     COLECCIONABLE_id INTEGER , 
     precio_dolar REAL , 
     COMIC_id INTEGER 
    )
; 
ALTER TABLE DUENO_HISTORICO 
    ADD CONSTRAINT Arc_1 CHECK ( 
        (  (COMIC_id IS NOT NULL) AND (COLECCIONABLE_id IS NULL) ) 
        OR 
        (  (COLECCIONABLE_id IS NOT NULL) AND (COMIC_id IS NULL) )  ) 
;

ALTER TABLE DUENO_HISTORICO ADD CONSTRAINT DUENO_HISTORICO_PK PRIMARY KEY  (COLECCIONISTA_documento_identidad, fecha_registro, id)
;

CREATE TABLE INTERES 
    (
     id SERIAL , 
     nombre VARCHAR (50) NOT NULL , 
     descripcion VARCHAR (100) NOT NULL 
    )
;

ALTER TABLE INTERES ADD CONSTRAINT INTERES_PK PRIMARY KEY  (id)
;

CREATE TABLE LISTADO 
    (
     id SERIAL , 
     orden INTEGER , 
     precio_base_dolar REAL NOT NULL , 
     precio_vendido_dolar REAL , 
     SUBASTA_id INTEGER NOT NULL , 
     DUENO_HISTORICO_COLECCIONISTA_documento_identidad INTEGER NOT NULL , 
     DUENO_HISTORICO_fecha_registro DATE NOT NULL , 
     PARTICIPANTE_subasta_id INTEGER , 
     DUENO_HISTORICO_id INTEGER NOT NULL , 
     PARTICIPANTE_id_inscripcion INTEGER 
    )
;

ALTER TABLE LISTADO ADD CONSTRAINT LISTADO_PK PRIMARY KEY  (SUBASTA_id, id)
;

CREATE TABLE LOCAL 
    (
     id SERIAL , 
     nombre VARCHAR (50) NOT NULL , 
     alquilado BOOLEAN NOT NULL , 
     LUGAR_id INTEGER NOT NULL , 
     COLECCIONISTA_documento_identidad INTEGER , 
     tipo VARCHAR (50) NOT NULL 
    )
; 


ALTER TABLE LOCAL 
    ADD 
    CHECK ( tipo IN ('Alquilado', 'De un Miembro') ) 
;

ALTER TABLE LOCAL ADD CONSTRAINT LOCAL_PK PRIMARY KEY  (id)
;

CREATE TABLE LUGAR 
    (
     id SERIAL , 
     nombre VARCHAR (50) NOT NULL , 
     tipo VARCHAR (50) NOT NULL , 
     LUGAR_id INTEGER 
    )
;

ALTER TABLE LUGAR ADD CONSTRAINT LUGAR_PK PRIMARY KEY  (id)
;

ALTER TABLE LUGAR 
    ADD 
    CHECK ( tipo IN ('Direccion', 'Ciudad', 'Estado', 'Pais') )
; 

CREATE TABLE MEMBRESIA 
    (
     fecha_ingreso DATE NOT NULL , 
     fecha_retiro DATE , 
     CLUB_id INTEGER NOT NULL , 
     COLECCIONISTA_documento_identidad INTEGER NOT NULL , 
     email_contacto VARCHAR (50) 
    )
;

ALTER TABLE MEMBRESIA ADD CONSTRAINT MEMBRESIA_PK PRIMARY KEY  (COLECCIONISTA_documento_identidad, CLUB_id, fecha_ingreso)
;

CREATE TABLE ORG_INV 
    (
     id SERIAL , 
     SUBASTA_id INTEGER NOT NULL , 
     CLUB_id INTEGER , 
     CLUB_id2 INTEGER 
    )
; 
ALTER TABLE ORG_INV 
    ADD CONSTRAINT Arc_2 CHECK ( 
        (  (CLUB_id IS NOT NULL) AND (CLUB_id2 IS NULL) ) 
        OR 
        (  (CLUB_id2 IS NOT NULL) AND (CLUB_id IS NULL) )  ) 
;

ALTER TABLE ORG_INV ADD CONSTRAINT ORG_INV_PK PRIMARY KEY  (id, SUBASTA_id)
;

CREATE TABLE ORG_SUB 
    (
     porcentaje INTEGER NOT NULL , 
     monto_recibido REAL , 
     ORGANIZACION_CARIDAD_id INTEGER NOT NULL , 
     SUBASTA_id INTEGER NOT NULL 
    )
;

ALTER TABLE ORG_SUB ADD CONSTRAINT ORG_SUB_PK PRIMARY KEY  (ORGANIZACION_CARIDAD_id, SUBASTA_id)
;

CREATE TABLE ORGANIZACION_CARIDAD 
    (
     id SERIAL , 
     nombre VARCHAR (50) NOT NULL , 
     mision VARCHAR (50) NOT NULL 
    )
;

ALTER TABLE ORGANIZACION_CARIDAD ADD CONSTRAINT ORGANIZACION_CARIDAD_PK PRIMARY KEY  (id)
;

CREATE TABLE PARTICIPANTE 
    (
     id_inscripcion INTEGER NOT NULL , 
     SUBASTA_id INTEGER NOT NULL , 
     MEMBRESIA_COLECCIONISTA_documento_identidad INTEGER NOT NULL , 
     MEMBRESIA_CLUB_id INTEGER NOT NULL , 
     MEMBRESIA_fecha_ingreso DATE NOT NULL , 
     autorizado BOOLEAN 
    )
;

ALTER TABLE PARTICIPANTE ADD CONSTRAINT PARTICIPANTE_PK PRIMARY KEY  (SUBASTA_id, id_inscripcion)
;

CREATE TABLE REPRESENTANTE 
    (
     documento_identidad INTEGER NOT NULL , 
     nombre VARCHAR (25) NOT NULL , 
     apellido VARCHAR (25) NOT NULL , 
     fecha_nacimiento DATE NOT NULL 
    )
;

ALTER TABLE REPRESENTANTE ADD CONSTRAINT REPRESENTANTE_PK PRIMARY KEY  (documento_identidad)
;

CREATE TABLE SUBASTA 
    (
     id SERIAL , 
     fecha DATE NOT NULL , 
     hora_inicio TIME NOT NULL , 
     hora_cierre TIME NOT NULL , 
     tipo VARCHAR (50) NOT NULL , 
     caridad BOOLEAN NOT NULL , 
     cancelado BOOLEAN NOT NULL , 
     LOCAL_id INTEGER NOT NULL 
    )
; 


ALTER TABLE SUBASTA 
    ADD 
    CHECK ( tipo IN ('Presencial', 'Virtual') ) 
;

ALTER TABLE SUBASTA ADD CONSTRAINT SUBASTA_PK PRIMARY KEY  (id)
;

ALTER TABLE CLU_INT 
    ADD CONSTRAINT CLU_INT_CLUB_FK FOREIGN KEY 
    ( 
     CLUB_id
    ) 
    REFERENCES CLUB 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE CLU_INT 
    ADD CONSTRAINT CLU_INT_INTERES_FK FOREIGN KEY 
    ( 
     INTERES_id
    ) 
    REFERENCES INTERES 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE CLUB 
    ADD CONSTRAINT CLUB_LUGAR_FK FOREIGN KEY 
    ( 
     LUGAR_id
    ) 
    REFERENCES LUGAR 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE CLUB 
    ADD CONSTRAINT CLUB_MEMBRESIA_FK FOREIGN KEY 
    ( 
     MEMBRESIA_COLECCIONISTA_documento_identidad, 
     MEMBRESIA_CLUB_id, 
     MEMBRESIA_fecha_ingreso
    ) 
    REFERENCES MEMBRESIA 
    ( 
     COLECCIONISTA_documento_identidad , 
     CLUB_id , 
     fecha_ingreso 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE COLECCIONISTA 
    ADD CONSTRAINT COLECCIONISTA_COLECCIONISTA_FK FOREIGN KEY 
    ( 
     COLECCIONISTA_documento_identidad
    ) 
    REFERENCES COLECCIONISTA 
    ( 
     documento_identidad 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE COLECCIONISTA 
    ADD CONSTRAINT COLECCIONISTA_LUGAR_FK FOREIGN KEY 
    ( 
     LUGAR_id
    ) 
    REFERENCES LUGAR 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE COLECCIONISTA 
    ADD CONSTRAINT COLECCIONISTA_LUGAR_FKv2 FOREIGN KEY 
    ( 
     LUGAR_id2
    ) 
    REFERENCES LUGAR 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE COLECCIONISTA 
    ADD CONSTRAINT COLECCIONISTA_REPRESENTANTE_FK FOREIGN KEY 
    ( 
     REPRESENTANTE_documento_identidad
    ) 
    REFERENCES REPRESENTANTE 
    ( 
     documento_identidad 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE CONTACTO 
    ADD CONSTRAINT CONTACTO_CLUB_FK FOREIGN KEY 
    ( 
     CLUB_id
    ) 
    REFERENCES CLUB 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE DUENO_HISTORICO 
    ADD CONSTRAINT DUENO_HISTORICO_COLECCIONABLE_FK FOREIGN KEY 
    ( 
     COLECCIONABLE_id
    ) 
    REFERENCES COLECCIONABLE 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE DUENO_HISTORICO 
    ADD CONSTRAINT DUENO_HISTORICO_COLECCIONISTA_FK FOREIGN KEY 
    ( 
     COLECCIONISTA_documento_identidad
    ) 
    REFERENCES COLECCIONISTA 
    ( 
     documento_identidad 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE DUENO_HISTORICO 
    ADD CONSTRAINT DUENO_HISTORICO_COMIC_FK FOREIGN KEY 
    ( 
     COMIC_id
    ) 
    REFERENCES COMIC 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE LISTADO 
    ADD CONSTRAINT LISTADO_DUENO_HISTORICO_FK FOREIGN KEY 
    ( 
     DUENO_HISTORICO_COLECCIONISTA_documento_identidad, 
     DUENO_HISTORICO_fecha_registro, 
     DUENO_HISTORICO_id
    ) 
    REFERENCES DUENO_HISTORICO 
    ( 
     COLECCIONISTA_documento_identidad , 
     fecha_registro , 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE LISTADO 
    ADD CONSTRAINT LISTADO_PARTICIPANTE_FK FOREIGN KEY 
    ( 
     PARTICIPANTE_subasta_id, 
     PARTICIPANTE_id_inscripcion
    ) 
    REFERENCES PARTICIPANTE 
    ( 
     SUBASTA_id , 
     id_inscripcion 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE LISTADO 
    ADD CONSTRAINT LISTADO_SUBASTA_FK FOREIGN KEY 
    ( 
     SUBASTA_id
    ) 
    REFERENCES SUBASTA 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE LOCAL 
    ADD CONSTRAINT LOCAL_COLECCIONISTA_FK FOREIGN KEY 
    ( 
     COLECCIONISTA_documento_identidad
    ) 
    REFERENCES COLECCIONISTA 
    ( 
     documento_identidad 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE LOCAL 
    ADD CONSTRAINT LOCAL_LUGAR_FK FOREIGN KEY 
    ( 
     LUGAR_id
    ) 
    REFERENCES LUGAR 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE LUGAR 
    ADD CONSTRAINT LUGAR_LUGAR_FK FOREIGN KEY 
    ( 
     LUGAR_id
    ) 
    REFERENCES LUGAR 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE MEMBRESIA 
    ADD CONSTRAINT MEMBRESIA_CLUB_FK FOREIGN KEY 
    ( 
     CLUB_id
    ) 
    REFERENCES CLUB 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE MEMBRESIA 
    ADD CONSTRAINT MEMBRESIA_COLECCIONISTA_FK FOREIGN KEY 
    ( 
     COLECCIONISTA_documento_identidad
    ) 
    REFERENCES COLECCIONISTA 
    ( 
     documento_identidad 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE ORG_INV 
    ADD CONSTRAINT ORG_INV_CLUB_FK FOREIGN KEY 
    ( 
     CLUB_id
    ) 
    REFERENCES CLUB 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE ORG_INV 
    ADD CONSTRAINT ORG_INV_CLUB_FKv2 FOREIGN KEY 
    ( 
     CLUB_id2
    ) 
    REFERENCES CLUB 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE ORG_INV 
    ADD CONSTRAINT ORG_INV_SUBASTA_FK FOREIGN KEY 
    ( 
     SUBASTA_id
    ) 
    REFERENCES SUBASTA 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE ORG_SUB 
    ADD CONSTRAINT ORG_SUB_ORGANIZACION_CARIDAD_FK FOREIGN KEY 
    ( 
     ORGANIZACION_CARIDAD_id
    ) 
    REFERENCES ORGANIZACION_CARIDAD 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE ORG_SUB 
    ADD CONSTRAINT ORG_SUB_SUBASTA_FK FOREIGN KEY 
    ( 
     SUBASTA_id
    ) 
    REFERENCES SUBASTA 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE PARTICIPANTE 
    ADD CONSTRAINT PARTICIPANTE_MEMBRESIA_FK FOREIGN KEY 
    ( 
     MEMBRESIA_COLECCIONISTA_documento_identidad, 
     MEMBRESIA_CLUB_id, 
     MEMBRESIA_fecha_ingreso
    ) 
    REFERENCES MEMBRESIA 
    ( 
     COLECCIONISTA_documento_identidad , 
     CLUB_id , 
     fecha_ingreso 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE PARTICIPANTE 
    ADD CONSTRAINT PARTICIPANTE_SUBASTA_FK FOREIGN KEY 
    ( 
     SUBASTA_id
    ) 
    REFERENCES SUBASTA 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;

ALTER TABLE SUBASTA 
    ADD CONSTRAINT SUBASTA_LOCAL_FK FOREIGN KEY 
    ( 
     LOCAL_id
    ) 
    REFERENCES LOCAL 
    ( 
     id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
;



-- Oracle SQL Developer Data Modeler Summary Report: 
-- 
-- CREATE TABLE                            18
-- CREATE INDEX                             1
-- ALTER TABLE                             50
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE SCHEMA                            0
-- CREATE SEQUENCE                          0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0

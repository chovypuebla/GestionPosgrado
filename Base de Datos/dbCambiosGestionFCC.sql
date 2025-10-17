Insert into coordinador (id_coordinador, usuario, contrasenia, rol)
values ('1', '201921492', 'rodorm24', 'coordinador');

Insert into alumno (matricula, nombre)
values ('201649351', 'Roberto Medina Mendoza');

Insert into curso (id_curso, nombre, periodo, anio, fechaRegistroCurso)
values ('1', 'Enseñanza de Matemáticas y Computación a Licenciatura', 'Primavera', '2026', '2025-09-30 12:00:00' );


alter table curso
alter column nombre varchar(255);

Select * from curso;

-- Modificaciones a la columna del nombre del curso
-- añadir en la db alumno, coordinador (indispensable para inicio de sesión)

--Añadir columna fecha de actualización, indispensable para las entidades Alumno y Docente

ALTER TABLE docente
ADD fechaActualizacion DATETIME;

ALTER TABLE alumno
ADD fechaActualizacion DATETIME;

ALTER TABLE alumno
ADD apellidoPaterno varchar(100);

ALTER TABLE alumno
ADD apellidoMaterno varchar(100);

ALTER TABLE docente
ADD apellidoPaterno varchar(100);

ALTER TABLE docente
ADD apellidoMaterno varchar(100);

-- sistema de gestión académica - posgrado fcc

-- Create database gestionFCC;

Use gestionFCC;

Create table alumno(
matricula varchar(9) primary key,
nombre varchar(100) not null,
direccion text,
telefono varchar(15),
celular varchar(15),
correo varchar(100),
correoBuap varchar(100),
);

Create table docente(
id_docente varchar(9) primary key,
nombre varchar(100) not null,
telefono varchar(15),
celular varchar(15),
nacimiento date,
adscripcion varchar(100), --facultad a la que pertenece
cubiculo varchar(100),
correoBuap varchar(100),
correoViep varchar(100),
tesista varchar(100), --tipo de tesista 
);

Create table coloquio(
id_coloquio varchar(10) primary key,
fecha date,
lugar varchar(100),
hora time,
);

Create table curso(
id_curso varchar(10) primary key,
nombre varchar(100) not null,
periodo varchar(100),
anio date, --año del curso
fechaRegistroCurso datetime2  default getdate()
);

Create table coordinador(
id_coordinador varchar(10) primary key, 
usuario varchar(10), --matircula asignada
contrasenia varchar(8), --se comprenderá de máximo 8 caracteres el uso de la contraseña para el usuario
rol varchar(20) default 'coordinador',
ultimoAcceso datetime null,
activo bit default 1
);

Create table expediente(
id_expediente varchar(10) primary key,
--rutas de archivo de los documentos
ine varchar(255),
cartaCompromiso varchar(255),
cartaRecomendacion1 varchar(255),
cartaRecomendacion2 varchar(255),
protocolo varchar(255),
comprobanteToefl varchar(255),
exani varchar(255),
tituloLicenciatura varchar(255),
tituloMaestria varchar(255),
cedulaLicenciatura varchar(255),
cedulaMaestria varchar(255),
curriculumVitae varchar(255),
publicaciones varchar(255),
kardexSemestral varchar(255),
pagoInscripcion varchar(255),

fechaCreacion datetime2 default getDate(),
fechaActualizacion datetime2 default getdate()
);

alter table alumno
add fechaRegistro datetime2  default getdate();

alter table coloquio
add fechaRegistroColoquio datetime2  default getdate();

alter table docente
add fechaRegistroDocente datetime2  default getdate();
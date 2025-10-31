CREATE TABLE DocenteCurso (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_curso VARCHAR(255) NOT NULL,
    id_docente VARCHAR(10) NOT NULL,
    fechaRegistro DATETIME NULL DEFAULT GETDATE(),
    periodo VARCHAR(255) NOT NULL,
    fechaAsignacion DATETIME NULL
);

CREATE TABLE AlumnoCurso (
    id INT PRIMARY KEY IDENTITY(1,1),
    id_curso VARCHAR(255) NOT NULL,
    matricula VARCHAR(10) NOT NULL,
    fechaAsignacion DATETIME NULL DEFAULT GETDATE(),
    periodo VARCHAR(255) NOT NULL
);
-- Limpiar registros existentes con NULLs
UPDATE Alumno 
SET 
    apellidoPaterno = ISNULL(apellidoPaterno, ''),
    apellidoMaterno = ISNULL(apellidoMaterno, ''),
    direccion = ISNULL(direccion, 'Sin dirección'),
    telefono = ISNULL(telefono, 'Sin teléfono'),
    celular = ISNULL(celular, 'Sin celular'),
    correo = ISNULL(correo, 'Sin correo'),
    fechaActualizacion = ISNULL(fechaActualizacion, GETDATE())
WHERE 
    apellidoPaterno IS NULL 
    OR apellidoMaterno IS NULL 
    OR direccion IS NULL 
    OR telefono IS NULL 
    OR celular IS NULL 
    OR correo IS NULL 
    OR fechaActualizacion IS NULL;

    Select * from alumno;

    -- Para Docente
UPDATE Docente 
SET 
    apellidoPaterno = ISNULL(apellidoPaterno, ''),
    apellidoMaterno = ISNULL(apellidoMaterno, ''),
    telefono = ISNULL(telefono, 'Sin teléfono'),
    celular = ISNULL(celular, 'Sin celular'),
    adscripcion = ISNULL(adscripcion, 'Sin adscripción'),
    cubiculo = ISNULL(cubiculo, 'Sin cubículo'),
    correoBuap = ISNULL(correoBuap, 'Sin correo BUAP'),
    correoViep = ISNULL(correoViep, 'Sin correo VIEP'),
    tesista = ISNULL(tesista, 'Sin tipo tesista'),
    fechaActualizacion = ISNULL(fechaActualizacion, GETDATE())
WHERE 
    apellidoPaterno IS NULL 
    OR apellidoMaterno IS NULL 
    OR telefono IS NULL 
    OR celular IS NULL 
    OR adscripcion IS NULL 
    OR cubiculo IS NULL 
    OR correoBuap IS NULL 
    OR correoViep IS NULL 
    OR tesista IS NULL 
    OR fechaActualizacion IS NULL;
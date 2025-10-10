Use gestionFCC;

--Verificar que existe la tabla de control
-- Select * from [__EFMigrationsHistory];

--verificar las tablas principales
Select TABLE_NAME 
from INFORMATION_SCHEMA.TABLES
where TABLE_TYPE = 'BASE TABLE';


# 1. Sistema de Gestión Académica de Posgrado


# Indice
- [1. Sistema de Gestión Académica de Posgrado](#1-sistema-de-gestión-académica-de-posgrado)
- [Indice](#indice)
  - [1.2. Objetivo del documento](#12-objetivo-del-documento)
  - [Herramientas de desarrollo utilizadas](#herramientas-de-desarrollo-utilizadas)
  - [Base de datos](#base-de-datos)
    - [Desarrollo del Script](#desarrollo-del-script)

## 1.2. Objetivo del documento

Este presente documento es realizar todas las anotaciones de desarrollo, para quien desee conntinuar con ello o en su debido caso realizar las modificaciones de acuerdo a lo que se presente.

Todo el proyecto es creado con fines educativos, en el repositorio en donde se encuentre ubicado puede no contener dependencias necesarias para la funcionalidad correcta del proyecto

## Herramientas de desarrollo utilizadas

- **C#**: Una vez descargado e instalado **Visual Studio** (versión gratuita), en la parte de seleccionar los **workloads** de manera en conjunto o individual es indispensable seleccionar el uso para aplicaciones web (**ASP.NET Core MVC**), uso de azure y herramientas de uso de bases de datos, es indispensable tener disponible en el equipo:
  - Aproximado de 20Gb de almacenamiento minímo para la instalación de las dependencias y carga de trabajo.
  - Conexión a internet con banda ancha competente
  - 8 gb de memoria RAM y un procesador i3, ryzen 3 o superiores.
- **SQL Server**: Puedes entrar a esta pagina **https://www.microsoft.com/es-mx/sql-server/sql-server-downloads** una vez instalado se te podrá recomendar en la página de inicio de SQL Server descargar su versión SSMS, en pocas palabras es utilizar la versión de interfaz gráfica de usuario, ya que solo usará en debido caso el uso de la version cmd de SQL
- Adicionales:
  - Git y controladores de versiones para ambas herramientas; facilitan el uso de git y github (si posees cuenta) en omitir el uso de comandos para agilizar los controles de versiones de la aplicación y modificaciones a la base de datos.
  - Todo el proyecto se esta utilizando las versiones gratuitas disponibles (no versiones de prueba)

## Base de datos

En el repositorio original puedas encontrar el script en sql que podrás descargar y utilizar en sql server, es importante tener en cuenta que se esta trabajando con la versión: **21**

### Desarrollo del Script

Una vez leído en la página 74 del documento del sistema se encuentra la figura 26 que es el diagrama de relación de la base de datos del sistema, en principio solo tiene relaciones **1 a N o N a 1**, en este caso no se están utilizando llaves foráneas por la razón de que es un sistema dirigido a una menor población a la que se maneja en la facultad, aquí estamos desarrollando un sistema de gestión para un posgrado que se entiende que la población es inferior a 1000 y no hay pruebas de que eso pueda superarse.

En la parte final del script se añadieron dos tres columnas una para cada tabla en uso y control de que la información se manipule con control de parte del sistema y no existan problemas a la hora de que llegue a sus manos del cliente.



Escrito y desarrollado por **Rodolfo Romero Miron**, *2025*
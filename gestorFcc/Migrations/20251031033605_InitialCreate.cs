using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestorFcc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    matricula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellidoPaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellidoMaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.matricula);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoCurso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_curso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matricula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    periodo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoCurso", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Coloquio",
                columns: table => new
                {
                    id_coloquio = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coloquio", x => x.id_coloquio);
                });

            migrationBuilder.CreateTable(
                name: "Coordinador",
                columns: table => new
                {
                    id_coordinador = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinador", x => x.id_coordinador);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    id_curso = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    periodo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaRegistroCurso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.id_curso);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    id_docente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellidoPaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    apellidoMaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    adscripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cubiculo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    correoBuap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correoViep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tesista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.id_docente);
                });

            migrationBuilder.CreateTable(
                name: "DocenteCurso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_curso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_docente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    periodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteCurso", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Expediente",
                columns: table => new
                {
                    id_expediente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartaCompromiso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartaRecomendacion1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cartaRecomendacion2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    protocolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comprobanteToefl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tituloLicenciatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tituloMaestria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cedulaLicenciatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cedulaMaestria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    curriculumVitae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publicaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kardexSemestral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pagoInscripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expediente", x => x.id_expediente);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "AlumnoCurso");

            migrationBuilder.DropTable(
                name: "Coloquio");

            migrationBuilder.DropTable(
                name: "Coordinador");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "DocenteCurso");

            migrationBuilder.DropTable(
                name: "Expediente");
        }
    }
}

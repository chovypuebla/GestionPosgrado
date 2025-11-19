using ClosedXML.Excel;
using gestorFcc.Data.Entidades;
using gestorFcc.Data;
using Microsoft.EntityFrameworkCore;

namespace gestorFcc.Servicios
{
    public class ExcelExportarServicio
    {
        private readonly ContextoAplicacionBD _context;

        public ExcelExportarServicio(ContextoAplicacionBD context)
        {
            _context = context;
        }

        public byte[] ExportarTodosDatos()
        {
            using (var wb = new XLWorkbook())
            {
                // Alumnos
                var alumnos = _context.Alumno.ToList();
                if (alumnos.Any())
                {
                    var ws = wb.Worksheets.Add("Alumnos");
                    ws.Cell(1, 1).Value = "Matrícula";
                    ws.Cell(1, 2).Value = "Nombre";
                    ws.Cell(1, 3).Value = "Apellido Paterno";
                    ws.Cell(1, 4).Value = "Apellido Materno";
                    ws.Cell(1, 5).Value = "Email";
                    ws.Cell(1, 6).Value = "Teléfono";

                    int row = 2;
                    foreach (var alumno in alumnos)
                    {
                        ws.Cell(row, 1).Value = alumno.matricula;
                        ws.Cell(row, 2).Value = alumno.nombre;
                        ws.Cell(row, 3).Value = alumno.apellidoPaterno;
                        ws.Cell(row, 4).Value = alumno.apellidoMaterno;
                        ws.Cell(row, 5).Value = alumno.correo;
                        ws.Cell(row, 6).Value = alumno.celular;
                        row++;
                    }
                    ws.Columns().AdjustToContents();
                }

                // Docentes
                var docentes = _context.Docente.ToList();
                if (docentes.Any())
                {
                    var ws = wb.Worksheets.Add("Docentes");
                    ws.Cell(1, 1).Value = "ID Docente";
                    ws.Cell(1, 2).Value = "Nombre";
                    ws.Cell(1, 3).Value = "Apellido Paterno";
                    ws.Cell(1, 4).Value = "Apellido Materno";
                    ws.Cell(1, 5).Value = "Email";
                    ws.Cell(1, 6).Value = "Teléfono";

                    int row = 2;
                    foreach (var docente in docentes)
                    {
                        ws.Cell(row, 1).Value = docente.id_docente;
                        ws.Cell(row, 2).Value = docente.nombre;
                        ws.Cell(row, 3).Value = docente.apellidoPaterno;
                        ws.Cell(row, 4).Value = docente.apellidoMaterno;
                        ws.Cell(row, 5).Value = docente.correoBuap;
                        ws.Cell(row, 6).Value = docente.celular;
                        row++;
                    }
                    ws.Columns().AdjustToContents();
                }

                // Cursos
                var cursos = _context.Curso.ToList();
                if (cursos.Any())
                {
                    var ws = wb.Worksheets.Add("Cursos");
                    ws.Cell(1, 1).Value = "ID Curso";
                    ws.Cell(1, 2).Value = "Nombre";
                    ws.Cell(1, 3).Value = "Periodo";

                    int row = 2;
                    foreach (var curso in cursos)
                    {
                        ws.Cell(row, 1).Value = curso.id_curso;
                        ws.Cell(row, 2).Value = curso.nombre;
                        ws.Cell(row, 3).Value = curso.periodo;
                        row++;
                    }
                    ws.Columns().AdjustToContents();
                }

                // Coloquios
                var coloquios = _context.Coloquio.ToList();
                if (coloquios.Any())
                {
                    var ws = wb.Worksheets.Add("Coloquios");
                    ws.Cell(1, 1).Value = "ID Coloquio";
                    ws.Cell(1, 2).Value = "Título";
                    ws.Cell(1, 3).Value = "Fecha";
                    ws.Cell(1, 4).Value = "Lugar";
                    ws.Cell(1, 5).Value = "Hora";

                    int row = 2;
                    foreach (var coloquio in coloquios)
                    {
                        ws.Cell(row, 1).Value = coloquio.id_coloquio;
                        ws.Cell(row, 2).Value = coloquio.titulo;
                        ws.Cell(row, 3).Value = coloquio.fecha?.ToString("dd/MM/yyyy");
                        ws.Cell(row, 4).Value = coloquio.lugar;
                        ws.Cell(row, 5).Value = coloquio.hora?.ToString();
                        row++;
                    }
                    ws.Columns().AdjustToContents();
                }

                using (var stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
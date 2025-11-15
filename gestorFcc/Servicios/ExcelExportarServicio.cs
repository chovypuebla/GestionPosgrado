using ClosedXML.Excel;
using gestorFcc.Models;
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
                //Alumnos
                var alumno = _context.Alumno.ToList();
                if (alumno.Any())
                {
                    var ws = wb.Worksheets.Add("Alumnos");
                    AddTableToWorkSheet(ws, alumno, "Lista Alumno");
                }

                //docente
                var docente = _context.Docente.ToList();
                if (docente.Any())
                {
                    var ws = wb.Worksheets.Add("Docentes");
                    AddTableToWorkSheet(ws, docente, "Lista Docente");
                }

                //curso
                var curso = _context.Curso.ToList();
                if (curso.Any())
                {
                    var ws = wb.Worksheets.Add("Cursos");
                    AddTableToWorkSheet(ws, curso, "Lista Curso");
                }

                //alumnoCurso
                var alumnoCurso = _context.AlumnoCurso.ToList();
                if (alumnoCurso.Any())
                {
                    var ws = wb.Worksheets.Add("AlumnoCursos");
                    AddTableToWorkSheet(ws, alumnoCurso, "Lista AlumnoCurso");
                }

                //coloquio
                var coloquio = _context.Coloquio.ToList();
                if (coloquio.Any())
                {
                    var ws = wb.Worksheets.Add("Coloquios");
                    AddTableToWorkSheet(ws, coloquio, "Lista Coloquio");
                }

                //docenteCurso
                var docenteCurso = _context.DocenteCurso.ToList();
                if (docenteCurso.Any())
                {
                    var ws = wb.Worksheets.Add("DocenteCursos");
                    AddTableToWorkSheet(ws, docenteCurso, "Lista DocenteCurso");
                }

                using (var stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        private void AddTableToWorkSheet<T> (IXLWorksheet wb, List<T> data, string titulo)
        {
            wb.Cell(1, 1).Value = titulo;
            wb.Cell(1,1).Style.Font.Bold = true;
            wb.Cell(1,1).Style.Font.FontSize = 14;

            //propiedades de la entidad
            var propiedades = typeof(T).GetProperties();

            //encabezados
            int row = 3;
            for (int col = 0; col < propiedades.Length; col++) 
            {
                wb.Cell(row, col + 1).Value = GetDisplayName(propiedades[col]);
                wb.Cell(row, col + 1).Style.Font.Bold = true;
                wb.Cell(row, col + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
            }

            row++;
            foreach (var item in data) {
                for (int col = 0; col < propiedades.Length; col++) 
                {
                    var valor = propiedades[col].GetValue(item);
                    wb.Cell(row, col + 1).Value = valor != null ? valor?.ToString() : "";
                }
                row++;
            }

            //ajustar columnas
            wb.Columns().AdjustToContents();

        }

        private string GetDisplayName(System.Reflection.PropertyInfo property) 
        {
            var displayName = property.Name switch
            {
                "id" => "ID",
                "id_curso" => "ID Curso",
                "id_docente" => "ID Docente",
                "id_alumno" => "ID Alumno",
                "nombre" => "Nombre",
                "apellido" => "Apellido",
                "email" => "Email",
                "telefono" => "Teléfono",
                "fechaRegistro" => "Fecha de Registro",
                "periodo" => "Periodo",
                "fechaAsignacion" => "Fecha de Asignación",
                "titulo" => "Título",
                "descripcion" => "Descripción",
                "fechaColoquio" => "Fecha del Coloquio",
                _ => property.Name
            };
            return displayName;

        }

    }
}

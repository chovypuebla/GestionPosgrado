
using Microsoft.EntityFrameworkCore;
using gestorFcc.Data.Entidades;

namespace gestorFcc.Data
{
    public class ContextoAplicacionBD : DbContext
    {
        //constructor - recibir la configuración de la conexión
        public ContextoAplicacionBD(DbContextOptions<ContextoAplicacionBD> options)
            : base(options)
        {
        }

        //tablas de la base de datos
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Coordinador> Coordinador { get; set; }
        public DbSet<Coloquio> Coloquio { get; set; }
        public DbSet<Expediente> Expediente { get; set; }

        //configuraciones adicionales
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<alumno>().ToTable("Alumnos");
        }
    }
}

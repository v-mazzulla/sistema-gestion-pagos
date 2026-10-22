using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<RolUsuario> RolesUsuarios { get; set; }

        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<MetodoPago> MetodosPago { get; set; }

        public DbSet<TipoGasto> TiposGasto { get; set; }

        public DbSet<AuditoriaTipoGasto> AuditoriasTipoGasto { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<Unico> Unico { get; set; }

        public DbSet<Recurrente> Recurrentes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }

}

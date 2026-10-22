using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        private ApplicationDbContext _context;

        public RepositorioAuditoria(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(AuditoriaTipoGasto nueva)
        {
            _context.AuditoriasTipoGasto.Add(nueva);
            _context.SaveChanges();
        }

        public List<AuditoriaTipoGasto> GetAuditoriasDeTipoGasto(int idTipoGasto)
        {
            return _context.AuditoriasTipoGasto
                .Include(a => a.TipoGasto)
                .Include(a => a.Administrador)
                .Where(a => a.TipoGasto != null && a.TipoGasto.Id == idTipoGasto)
                .ToList();
        }
    }
}

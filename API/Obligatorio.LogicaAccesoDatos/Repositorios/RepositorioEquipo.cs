using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private ApplicationDbContext _context;

        public RepositorioEquipo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Equipo nuevo)
        {
            _context.Equipos.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Equipo> FindAll()
        {
            return _context.Equipos.ToList();
        }

        public Equipo FindById(int id)
        {
            return _context.Equipos.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
            Equipo aEliminar = FindById(id);
            if (aEliminar is not null)
            {
                _context.Equipos.Remove(aEliminar);
                _context.SaveChanges();
            }
        }

        public void Update(Equipo actualizado)
        {
            _context.Equipos.Update(actualizado);
            _context.SaveChanges();
        }

        public List<Equipo> EquiposConPagoUnicoMayor(int monto)
        {
            return _context.Equipos
                .Where(e => e.Usuarios
                .Any(u => u.Pagos
                .Any(p => p is Unico && p.Monto > monto)))
                .OrderByDescending(e => e.Nombre)
                .ToList();
        }
    }
}

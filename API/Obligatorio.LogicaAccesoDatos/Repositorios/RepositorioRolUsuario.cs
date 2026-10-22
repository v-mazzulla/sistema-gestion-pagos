using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioRolUsuario : IRepositorioRolUsuario
    {
        private ApplicationDbContext _context;

        public RepositorioRolUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(RolUsuario nuevo)
        {
            _context.RolesUsuarios.Add(nuevo);
            _context.SaveChanges();
        }

        public List<RolUsuario> FindAll()
        {
            return _context.RolesUsuarios.ToList();
        }

        public RolUsuario FindById(int id)
        {
            return _context.RolesUsuarios.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
            RolUsuario aEliminar = FindById(id);
            _context.RolesUsuarios.Remove(aEliminar);
            _context.SaveChanges();
        }

        public void Update(RolUsuario actualizado)
        {
            _context.RolesUsuarios.Update(actualizado);
            _context.SaveChanges();
        }
    }
}

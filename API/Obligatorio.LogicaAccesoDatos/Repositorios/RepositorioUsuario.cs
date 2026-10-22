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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Usuario nuevo)
        {
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Usuario> FindAll()
        {
            return _context.Usuarios.Include(u => u.Rol).Include(u => u.Equipo).ToList();
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.Include(u => u.Rol).Include(u => u.Equipo).Include(u => u.Pagos).Where(u => u.Email == email).SingleOrDefault();
        }

        public List<Pago> GetPagosDeUsuario(string email)
        {
            return _context.Pagos.Include(p => p.Usuario)
                .Include(p => p.TipoGasto)
                .Include(p => p.Metodo)
                .Where(p => p.Usuario.Email == email)
                .ToList();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Where(u => u.Id == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario actualizado)
        {
            _context.Usuarios.Update(actualizado);
            _context.SaveChanges();
        }
    }
}

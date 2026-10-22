using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioTipoGasto : IRepositorioTipoGasto
    {
        private ApplicationDbContext _context;

        public RepositorioTipoGasto(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(TipoGasto nuevo)
        {
            _context.TiposGasto.Add(nuevo);
            _context.SaveChanges();
        }

        public List<TipoGasto> FindAll()
        {
            return _context.TiposGasto.Where(x => x.Activo).ToList();
        }

        public TipoGasto FindById(int id)
        {
            return _context.TiposGasto.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
            TipoGasto AElminar = FindById(id);
            AElminar.Activo = false;
            _context.SaveChanges();
        }

        public void Update(TipoGasto actualizado)
        {
            _context.TiposGasto.Update(actualizado);
            _context.SaveChanges();
        }
    }
}

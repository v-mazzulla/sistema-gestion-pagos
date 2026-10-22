using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioMetodoPago : IRepositorioMetodoPago
    {
        private ApplicationDbContext _context;

        public RepositorioMetodoPago(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MetodoPago> FindAll()
        {
            return _context.MetodosPago.ToList();
        }

        public MetodoPago FindById(int id)
        {
            return _context.MetodosPago.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}

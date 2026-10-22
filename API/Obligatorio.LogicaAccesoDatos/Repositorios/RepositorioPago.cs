using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio.LogicaAccesoDatos.Repositorios
{
    public class RepositorioPago : IRepositorioPago
    {
        private ApplicationDbContext _context;

        public RepositorioPago(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Pago nuevo)
        {
            _context.Pagos.Add(nuevo);
            _context.SaveChanges();
        }

        public Pago FindById(int id)
        {
            return _context.Pagos
                .Include(p => p.Metodo)
                .Include(p => p.TipoGasto)
                .Include(p => p.Usuario)
                .SingleOrDefault(p => p.Id == id);
        }

        public List<Pago> FindAll()
        {
            return _context.Pagos.ToList();
        }

        /// <summary>
        /// Busca pagos unicos realizados en un mes y año determinados y pagos recurrentes de los que se reaizara un pago en dicho mes y año
        /// Luego une estas dos listas
        /// </summary>
        /// <param name="m"></param>
        /// <param name="y"></param>
        /// <returns> List<Pago> </returns>
        public List<Pago> ListByMonth(int m, int y)
        {
            var unicos = _context.Pagos.OfType<Unico>().Include(u => u.Metodo).Include(u => u.TipoGasto).Include(u => u.TipoGasto).Include(u => u.Usuario)
                .Where(u => u.Fecha.Month == m && u.Fecha.Year == y).ToList();

            var recurrentes = _context.Pagos.OfType<Recurrente>().Include(u => u.Metodo).Include(u => u.TipoGasto).Include(u => u.TipoGasto).Include(u => u.Usuario)
                .Where(r =>
                    // Comienza antes o en el mes/año actual
                    (r.FechaDesde.Year < y || (r.FechaDesde.Year == y && r.FechaDesde.Month <= m))
                    &&
                    // Termina después o en el mes/año actual
                    (r.FechaHasta.Year > y || (r.FechaHasta.Year == y && r.FechaHasta.Month >= m))).ToList();

            List<Pago> pList = unicos.Cast<Pago>().ToList();
            pList.AddRange(recurrentes.Cast<Pago>());

            return pList;
        }
    }
}

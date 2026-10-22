using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPago
    {
        void Add(Pago nuevo);
        Pago FindById(int id);
        List<Pago> FindAll();
        public List<Pago> ListByMonth(int m, int y);
    }
}

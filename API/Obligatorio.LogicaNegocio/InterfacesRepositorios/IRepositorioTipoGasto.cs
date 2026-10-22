using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioTipoGasto
    {
        void Add(TipoGasto nuevo);
        TipoGasto FindById(int id);
        List<TipoGasto> FindAll();
        void Remove(int id);
        void Update(TipoGasto actualizado);
    }
}

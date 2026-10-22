using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto
{
    public interface ICUEliminarTipoGasto
    {
        void EliminarTipoGasto(int id, string emailLogueado);
    }
}

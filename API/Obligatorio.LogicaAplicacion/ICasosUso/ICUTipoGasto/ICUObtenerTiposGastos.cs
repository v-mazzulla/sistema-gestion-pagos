using Obligatorio.DTOs.DTOsTipoGasto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto
{
    public interface ICUObtenerTiposGastos
    {
        List<DTOTipoGasto> ObtenerTiposGastos();
    }
}

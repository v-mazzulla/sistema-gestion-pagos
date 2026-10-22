using Obligatorio.DTOs.DTOsEquipo;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo
{
    public interface ICUEquiposPagoUnicoMayor
    {
        List<DTOEquipo> ObtenerEquiposConPagoUnicoMayor(int monto);
    }
}

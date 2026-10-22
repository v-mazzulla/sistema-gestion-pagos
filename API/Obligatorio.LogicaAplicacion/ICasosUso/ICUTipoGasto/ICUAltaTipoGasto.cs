using Obligatorio.DTOs.DTOsTipoGasto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto
{
    public interface ICUAltaTipoGasto
    {
        void AltaTipoGasto(DTOAltaTipoGasto dto, string emailLogueado);
    }
}

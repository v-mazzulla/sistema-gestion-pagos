using Obligatorio.DTOs.DTOsAuditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria
{
    public interface ICUAuditoriasDeTipoGasto
    {
        List<DTOAuditoria> AuditoriasDeTipoGasto(int idTipoGasto);
    }
}

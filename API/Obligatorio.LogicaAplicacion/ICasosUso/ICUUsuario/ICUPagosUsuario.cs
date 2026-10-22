using Obligatorio.DTOs.DTOsPago;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario
{
    public interface ICUPagosUsuario
    {
        List<DTOPago> PagosDeUsuario(string email);
    }
}

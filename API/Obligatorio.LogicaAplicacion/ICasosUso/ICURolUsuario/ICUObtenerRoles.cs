using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICURolUsuario
{
    public interface ICUObtenerRoles
    {
        List<RolUsuario> ObtenerRoles();
    }
}

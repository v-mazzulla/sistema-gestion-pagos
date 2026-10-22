using Obligatorio.LogicaAplicacion.ICasosUso.ICURolUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CURolUsuario
{
    public class CUObtenerRoles : ICUObtenerRoles
    {
        private IRepositorioRolUsuario _repoRolUsuario;

        public CUObtenerRoles(IRepositorioRolUsuario repoRolUsuario)
        {
            _repoRolUsuario = repoRolUsuario;
        }

        public List<RolUsuario> ObtenerRoles()
        {
            List<RolUsuario> roles = _repoRolUsuario.FindAll();
            return roles;
        }
    }
}

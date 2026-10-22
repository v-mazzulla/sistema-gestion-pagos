using Obligatorio.DTOs.DTOsPago;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUPagosUsuario : ICUPagosUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        public CUPagosUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public List<DTOPago> PagosDeUsuario(string email)
        {
            List<Pago> pagos = _repoUsuario.GetPagosDeUsuario(email);
            if (pagos is not null)
            {
                List<DTOPago> pagosDTO = MapperPago.ToDTOPagoList(pagos);
                return pagosDTO;
            }
            else
            {
                throw new NotFoundException("Usuario no encontrado");
            }
        }
    }
}

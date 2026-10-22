using Obligatorio.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUUsuariosXMontoPago : ICUUsuariosXMontoPago
    {
        IRepositorioUsuario _repoUsuario;
        IRepositorioPago _repoPago;

        public CUUsuariosXMontoPago(IRepositorioUsuario repoUsuarios,
                                    IRepositorioPago repoPago)
        {
            _repoUsuario = repoUsuarios;
            _repoPago = repoPago;
        }

        public List<DTOUsuario> UsuariosXMontoPago(double monto)
        {
            List<Usuario> listUsuarios = _repoUsuario.FindAll();
            List<Pago> listPago = _repoPago.FindAll();

            List<Usuario> listUsuariosXPago = 
                listPago.SelectMany(p => listUsuarios.Where(u => u == p.Usuario && p.MontoTotal() > monto)).Distinct().ToList();
            
            List<DTOUsuario> listDTO = MapperUsuario.ToDTOUsuarioList(listUsuariosXPago);

            return listDTO;
        }

    }
}


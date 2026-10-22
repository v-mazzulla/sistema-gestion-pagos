using Obligatorio.DTOs.DTOsPago;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago
{
    public class CUAltaPago : ICUAltaPago
    {
        private IRepositorioPago _repoPago;
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioMetodoPago _repoMetodo;
        private IRepositorioUsuario _repoUsuario;

        public CUAltaPago(IRepositorioPago repopago, IRepositorioTipoGasto repoTipoGasto,
           IRepositorioMetodoPago repoMetodo, IRepositorioUsuario repoUsuario )
        {
            _repoPago = repopago;
            _repoTipoGasto = repoTipoGasto;
            _repoMetodo = repoMetodo;
            _repoUsuario = repoUsuario;
        }

        public void AltaPago(DTOAltaPago dto, string emailLogueado)
        {
            if (dto.Descripcion == null)
            {
                throw new DatosInvalidosException("La descripcion es obligatoria");
            }
            Pago nuevo = MapperPago.FromDTOAltaPagoToPago(dto);
            
            TipoGasto tipoGasto = _repoTipoGasto.FindById(dto.IdTipoGasto);
            nuevo.TipoGasto = tipoGasto;

            MetodoPago metodo = _repoMetodo.FindById(dto.IdMetodo);
            nuevo.Metodo = metodo;

            Usuario usuario = _repoUsuario.FindByEmail(emailLogueado);
            nuevo.Usuario = usuario;

            
            nuevo.Validar();
            _repoPago.Add(nuevo);
        }
    }
}

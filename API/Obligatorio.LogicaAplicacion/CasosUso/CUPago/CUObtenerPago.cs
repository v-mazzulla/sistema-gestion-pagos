using Obligatorio.DTOs.DTOsPago;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaNegocio.CustomExceptions.CEPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago
{
    public class CUObtenerPago : ICUObtenerPago
    {
        private IRepositorioPago _repoPago;

        public CUObtenerPago(IRepositorioPago repoPago)
        {
            _repoPago = repoPago;
        }

        public DTOPago ObtenerPago(int id)
        {
            Pago buscado = _repoPago.FindById(id);
            if (buscado is not null)
            {
                DTOPago dto = MapperPago.FromPagoToDTOPago(buscado);
                return dto;
            }
            else
            {
                throw new PagoNoEncontradoException();
            }
        }
    }
}

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

namespace Obligatorio.LogicaAplicacion.CasosUso.CUPago
{
    public class CUObtenerPagosMes : ICUObtenerPagosMes

    {
        IRepositorioPago _repoPago;

        public CUObtenerPagosMes(IRepositorioPago repoPago)
        {
            _repoPago = repoPago;
        }

        public List<DTOPago> ObtenerPagosMes(int m, int y)
        {
            List<Pago> listPagosMes = _repoPago.ListByMonth( m, y);
            List<DTOPago> listDTO = MapperPago.ToDTOPagoList(listPagosMes);
            return listDTO;
        }
    }
}

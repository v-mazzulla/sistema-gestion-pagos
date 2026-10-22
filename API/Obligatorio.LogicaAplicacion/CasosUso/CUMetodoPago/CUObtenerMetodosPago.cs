using Obligatorio.DTOs.DTOsMetodoPago;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUMetodoPago;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUMetodoPago
{
    public class CUObtenerMetodosPago : ICUObtenerMetodosPago
    {
        IRepositorioMetodoPago _repoMetodoPago;

        public CUObtenerMetodosPago(IRepositorioMetodoPago repoMetodoPago)
        {
            _repoMetodoPago = repoMetodoPago;
        }

        public List<DTOMetodoPago> ObtenerMetodosPago()
        {
            List<MetodoPago> listMetodoPago = _repoMetodoPago.FindAll();
            List<DTOMetodoPago> listDTO = MapperMetodoPago.ToDTOMetodoPagoList(listMetodoPago);
            return listDTO;
        }
    }
}

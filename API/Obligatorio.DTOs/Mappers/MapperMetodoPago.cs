using Obligatorio.DTOs.DTOsMetodoPago;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperMetodoPago
    {
        public static DTOMetodoPago FromMetodoPagoToDTOMetodoPago(MetodoPago mp)
        {
            DTOMetodoPago dto = new DTOMetodoPago();
            dto.Id = mp.Id;
            dto.Nombre = mp.Nombre;
            return dto;
        }

        public static List<DTOMetodoPago> ToDTOMetodoPagoList(List<MetodoPago> listMetodoPago)
        {
            List<DTOMetodoPago> listDTO = new List<DTOMetodoPago>();
            foreach (MetodoPago mp in listMetodoPago)
            {
                listDTO.Add(FromMetodoPagoToDTOMetodoPago(mp));
            }
            return listDTO;
        }
    }
}

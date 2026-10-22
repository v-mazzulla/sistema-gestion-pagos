using Obligatorio.DTOs.DTOsPago;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperPago
    {
        public static Pago FromDTOAltaPagoToPago(DTOAltaPago dto)
        {

            if (dto.TipoPago == "unico")
            {
                Unico p = new Unico();
                p.Descripcion = dto.Descripcion;
                p.Monto = dto.Monto;
                p.Fecha = (DateTime)dto.Fecha;
                p.NroRecibo = (int)dto.NroRecibo;

                return p;
            }
            else
            {
                Recurrente p = new Recurrente();
                p.Descripcion = dto.Descripcion;
                p.Monto = dto.Monto;
                p.FechaDesde = (DateTime)dto.FechaDesde;
                p.FechaHasta = (DateTime)dto.FechaHasta;
                return p;
            }

        }

       public static DTOPago FromPagoToDTOPago(Pago p)
        {
            DTOPago dto = new DTOPago();
            dto.Id = p.Id;
            dto.Metodo = p.Metodo.Nombre;
            dto.TipoGasto = p.TipoGasto.Nombre;
            dto.TipoPago = p.GetType().Name;
            dto.Usuario = (p.Usuario.Nombre + " " + p.Usuario.Apellido);
            dto.Descripcion = p.Descripcion;
            dto.Monto = p.Monto;
            dto.SaldoPendiente = p.SaldoPendiente();
            return dto;
        }

        public static List<DTOPago> ToDTOPagoList(List<Pago> listPago)
        {
            List<DTOPago> listDTO = new List<DTOPago>();
            foreach (Pago p in listPago)
            {
                listDTO.Add(FromPagoToDTOPago(p));
            }
            return listDTO;
        }

    }
}
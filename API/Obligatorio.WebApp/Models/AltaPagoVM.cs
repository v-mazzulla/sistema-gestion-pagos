using Obligatorio.DTOs.DTOsPago;
using Obligatorio.DTOs.DTOsTipoGasto;
using Obligatorio.DTOs.DTOsMetodoPago;

namespace Obligatorio.WebApp.Models
{
    public class AltaPagoVM
    {
        public DTOAltaPago Dto { get; set; }

        public List<DTOTipoGasto> TiposDeGasto { get; set; } = new List<DTOTipoGasto>();

        public List<DTOMetodoPago> MetodosPago { get; set; } = new List<DTOMetodoPago>();
    }
}

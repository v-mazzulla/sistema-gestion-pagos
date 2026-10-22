using Obligatorio.DTOs.DTOsPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUPago
{
    public interface ICUAltaPago
    {
        void AltaPago(DTOAltaPago dto, string emailLogueado);
    }
}

using Obligatorio.DTOs.DTOsMetodoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUMetodoPago
{
    public interface ICUObtenerMetodosPago
    {
        List<DTOMetodoPago> ObtenerMetodosPago();
    }
}

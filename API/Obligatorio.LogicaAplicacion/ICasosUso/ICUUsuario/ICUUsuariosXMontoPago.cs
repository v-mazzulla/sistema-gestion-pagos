using Obligatorio.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario
{
    public interface ICUUsuariosXMontoPago
    {
        public List<DTOUsuario> UsuariosXMontoPago(double monto);
    }
}

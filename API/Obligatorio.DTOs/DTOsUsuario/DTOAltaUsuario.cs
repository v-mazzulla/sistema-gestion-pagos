using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOsUsuario
{
    public class DTOAltaUsuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public int IdRolSeleccionado { get; set; }
        public string Equipo { get; set; }
        public int IdEquipoSeleccionado { get; set; }
    }
}

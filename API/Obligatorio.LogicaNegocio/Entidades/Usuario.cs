using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public RolUsuario Rol {  get; set; }
        public Equipo Equipo { get; set; }
        public List<Pago>? Pagos { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new DatosInvalidosException("El nombre no puede estar vacío");
            }
            if (string.IsNullOrWhiteSpace(Apellido))
            {
                throw new DatosInvalidosException("El apellido no puede estar vacío");
            }
        }
    }
}

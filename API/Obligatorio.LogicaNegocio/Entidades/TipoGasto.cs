using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class TipoGasto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; } = true;

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new DatosInvalidosException("El nombre es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                throw new DatosInvalidosException("La descrripcion es obligatoria");
            }
        }
    }
}

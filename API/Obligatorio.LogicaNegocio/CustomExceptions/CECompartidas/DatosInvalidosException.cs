using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas
{
    public class DatosInvalidosException : Exception
    {
        public DatosInvalidosException()
        {
        }

        public DatosInvalidosException(string? message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.CustomExceptions.CEPago
{
    public class PagoNoEncontradoException : Exception
    {
        public PagoNoEncontradoException()
        {
        }

        public PagoNoEncontradoException(string? message) : base(message)
        {
        }
    }
}

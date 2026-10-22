using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Unico : Pago
    {
        public DateTime Fecha { get; set; }
        public int NroRecibo { get; set; }

        public override double SaldoPendiente()
        {
            return 0;
        }

        public override void Validar()
        {
            base.Validar();
            if(NroRecibo <= 0)
            {
                throw new DatosInvalidosException("El numero de recibo debe ser positivo");
            }
            if(Fecha == DateTime.MinValue)
            {
                throw new DatosInvalidosException("La fecha es obligatoria");
            }
        }
    }
}


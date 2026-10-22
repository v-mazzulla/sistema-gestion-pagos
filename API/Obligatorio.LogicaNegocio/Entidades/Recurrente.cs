using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Recurrente : Pago
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public override double MontoTotal()
        {
            return FechaHasta.Month - FechaDesde.Month + 12 * FechaHasta.Year - FechaDesde.Year;
        }

        public override double SaldoPendiente()
        {
            int meses = 0;
            DateTime hoy = DateTime.Today;

            if (hoy < FechaHasta)
            {
                meses = (hoy.Month - FechaDesde.Month) + 12 * (hoy.Year - FechaDesde.Year);
            }

            return (meses * Monto);
        }

        public override void Validar()
        {
            base.Validar();
            if(FechaHasta == DateTime.MinValue || FechaDesde == DateTime.MinValue)
            {
                throw new DatosInvalidosException("La fecha es obligatoria");
            }
            if (FechaDesde > FechaHasta)
            {
                throw new DatosInvalidosException("La fecha desde debe ser menor a la fecha hasta");
            }
        }
    }
}

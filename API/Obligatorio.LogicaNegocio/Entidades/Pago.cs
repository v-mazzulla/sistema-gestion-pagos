using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public abstract class Pago
    {
        public int Id { get; set; }
        public MetodoPago Metodo { get; set; }
        public TipoGasto TipoGasto { get; set; }
        public Usuario Usuario { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }

        public virtual double MontoTotal()
        {
            return Monto;
        }
        public abstract double SaldoPendiente();


        public virtual void Validar()
        {
            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                throw new DatosInvalidosException("La descripcion es obligatoria");
            }
            if (Monto <= 0)
            {
                throw new DatosInvalidosException("El monto debe ser mayor a 0");
            }            
        }
    }
}

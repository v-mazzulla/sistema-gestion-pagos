using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio.DTOs.DTOsPago
{
    public class DTOAltaPago
    {
        public string TipoPago { get; set; }
        public int IdMetodo { get; set; }
        public  int IdTipoGasto { get; set; }
        // public int IdUsuario { get; set; }
        
        public string? Descripcion { get; set; }
        //nulleable solo xq si no no llega hasta las validaciones y si me sigue imprimiendo el error message automatico voy a enloquecer
        public double Monto { get; set; }

        //Recurrente
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }

        //Unico
        public DateTime? Fecha { get; set; }
        public int? NroRecibo { get; set; }
    }
}

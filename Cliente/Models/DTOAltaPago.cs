namespace HTTPClienteObligatorio.Models
{
    public class DTOAltaPago
    {
        public string TipoPago { get; set; }
        public int IdMetodo { get; set; }
        public  int IdTipoGasto { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }

        //Recurrente
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }

        //Unico
        public DateTime? Fecha { get; set; }
        public int? NroRecibo { get; set; }
    }
}

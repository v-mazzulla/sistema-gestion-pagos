namespace HTTPClienteObligatorio.Models
{
    public class DTOPago
    {
        public int Id { get; set; }
        public string TipoPago { get; set; }
        public string Metodo { get; set; }
        public string TipoGasto { get; set; }
        public string Usuario { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }

        ///
        public double SaldoPendiente { get; set; }
    }
}

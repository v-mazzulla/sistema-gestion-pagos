namespace HTTPClienteObligatorio.Models
{
    public class DTOAuditoria
    {
        public int Id { get; set; }
        public string AccionRealizada { get; set; }
        public DateTime Fecha { get; set; }
        public string Administrador { get; set; }
        public string TipoGasto { get; set; }
    }
}

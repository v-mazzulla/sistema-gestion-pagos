using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class AuditoriaTipoGasto
    {
        public int Id { get; set; }
        public string AccionRealizada { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario? Administrador { get; set; }
        public TipoGasto? TipoGasto { get; set; }
    }
}

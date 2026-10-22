using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.DTOsAuditoria
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

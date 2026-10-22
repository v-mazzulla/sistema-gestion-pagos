using Obligatorio.DTOs.DTOsAuditoria;
using Obligatorio.DTOs.DTOsPago;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperAuditoria
    {
        public static DTOAuditoria ToDTOAuditoria(AuditoriaTipoGasto aud)
        {
            DTOAuditoria dto = new DTOAuditoria();
            dto.AccionRealizada = aud.AccionRealizada;
            dto.Fecha = aud.Fecha;
            dto.Administrador = aud.Administrador.Nombre + " " + aud.Administrador.Apellido;
            dto.TipoGasto = aud.TipoGasto.Nombre;

            return dto;
        }

        public static List<DTOAuditoria> ToDTOAuditoriaList(List<AuditoriaTipoGasto> listAuditoria)
        {
            List<DTOAuditoria> listDTO = new List<DTOAuditoria>();
            foreach (AuditoriaTipoGasto a in listAuditoria)
            {
                listDTO.Add(ToDTOAuditoria(a));
            }
            return listDTO;
        }

    }
}

using Obligatorio.DTOs.DTOsAuditoria;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUAuditoria
{
    public class CUAuditoriasDeTipoGasto : ICUAuditoriasDeTipoGasto
    {
        private IRepositorioAuditoria _repoAuditoria;
        public CUAuditoriasDeTipoGasto(IRepositorioAuditoria repoAuditoria)
        {
            _repoAuditoria = repoAuditoria;
        }

        public List<DTOAuditoria> AuditoriasDeTipoGasto(int idTipoGasto)
        {
            List<AuditoriaTipoGasto> listaAuditorias = _repoAuditoria.GetAuditoriasDeTipoGasto(idTipoGasto);

            if (listaAuditorias == null || listaAuditorias.Count == 0)
            {
                throw new NotFoundException($"No existen auditorias para el tipo de gasto con id {idTipoGasto}");
            }
            else
            {
                return MapperAuditoria.ToDTOAuditoriaList(listaAuditorias);
            }
        }
    }
}

using Obligatorio.DTOs.DTOsTipoGasto;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUTipoGasto
{
    public class CUAltaTipoGasto : ICUAltaTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;
        public CUAltaTipoGasto(IRepositorioTipoGasto repoTipoGasto, IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoTipoGasto = repoTipoGasto;
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public void AltaTipoGasto(DTOAltaTipoGasto dto, string emailLogueado)
        {
            try
            {
                TipoGasto nuevo = MapperTipoGasto.FromDTOAltaTipoGastoToTipoGasto(dto);
                nuevo.Validar();
                _repoTipoGasto.Add(nuevo);

                AuditoriaTipoGasto aud = new AuditoriaTipoGasto();
                aud.AccionRealizada = "Alta";
                aud.TipoGasto = nuevo;
                aud.Fecha = DateTime.Now;
                aud.Administrador = _repoUsuario.FindByEmail(emailLogueado);
                _repoAuditoria.Add(aud);
            }
            catch (Exception e)
            {
                AuditoriaTipoGasto aud = new AuditoriaTipoGasto();
                aud.AccionRealizada = "Alta - Error";
                aud.TipoGasto = null;
                aud.Fecha = DateTime.Now;
                aud.Administrador = _repoUsuario.FindByEmail(emailLogueado);
                _repoAuditoria.Add(aud);
                throw e;
            }
        }
    }
}

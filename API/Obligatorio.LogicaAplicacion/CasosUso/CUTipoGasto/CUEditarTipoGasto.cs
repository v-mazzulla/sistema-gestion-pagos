using Obligatorio.DTOs.DTOsTipoGasto;
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
    public class CUEditarTipoGasto : ICUEditarTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUEditarTipoGasto(IRepositorioTipoGasto repoTipoGasto, IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoTipoGasto = repoTipoGasto;
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public void EditarTipoGasto(DTOTipoGasto dto, string emailLogueado)
        {
            try
            {
                TipoGasto aActualizar = _repoTipoGasto.FindById(dto.Id);
                if (aActualizar is not null)
                {
                    aActualizar.Nombre = dto.Nombre;
                    aActualizar.Descripcion = dto.Descripcion;
                    _repoTipoGasto.Update(aActualizar);

                    AuditoriaTipoGasto aud = new AuditoriaTipoGasto();
                    aud.AccionRealizada = "Editar";
                    aud.TipoGasto = aActualizar;
                    aud.Administrador = _repoUsuario.FindByEmail(emailLogueado);
                    aud.Fecha = DateTime.Now;
                    _repoAuditoria.Add(aud);
                }
                else
                {
                    throw new Exception("Tipo de gasto no encontrado");
                }
            }
            catch (Exception e)
            {
                AuditoriaTipoGasto aud = new AuditoriaTipoGasto();
                aud.AccionRealizada = "Editar - Error";
                aud.TipoGasto = null;
                aud.Administrador = _repoUsuario.FindByEmail(emailLogueado);
                aud.Fecha = DateTime.Now;
                _repoAuditoria.Add(aud);
                throw e;
            }
        }
    }
}

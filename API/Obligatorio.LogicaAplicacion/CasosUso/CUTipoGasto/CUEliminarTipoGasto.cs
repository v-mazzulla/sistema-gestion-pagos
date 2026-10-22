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
    public class CUEliminarTipoGasto : ICUEliminarTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUEliminarTipoGasto(IRepositorioTipoGasto repoTipoGasto, IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoTipoGasto = repoTipoGasto;
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public void EliminarTipoGasto(int id, string emailLogueado)
        {
            try
            {
                _repoTipoGasto.Remove(id);

                TipoGasto tg = _repoTipoGasto.FindById(id);

                AuditoriaTipoGasto aud = new AuditoriaTipoGasto();
                aud.AccionRealizada = "Eliminar";
                aud.TipoGasto = tg;
                aud.Administrador = _repoUsuario.FindByEmail(emailLogueado);
                aud.Fecha = DateTime.Now;
                _repoAuditoria.Add(aud);
            }
            catch (Exception e)
            {
                AuditoriaTipoGasto aud = new AuditoriaTipoGasto();
                aud.AccionRealizada = "Eliminar - Error";
                aud.TipoGasto = null;
                aud.Administrador = _repoUsuario.FindByEmail(emailLogueado);
                aud.Fecha = DateTime.Now;
                _repoAuditoria.Add(aud);
                throw e;
            }
        }
    }
}

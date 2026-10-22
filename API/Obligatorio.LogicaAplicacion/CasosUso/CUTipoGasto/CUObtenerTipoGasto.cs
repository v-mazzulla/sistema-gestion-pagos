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
    public class CUObtenerTipoGasto : ICUObtenerTipoGasto
    {
        private IRepositorioTipoGasto _repoTipoGasto;

        public CUObtenerTipoGasto(IRepositorioTipoGasto repoTipoGasto)
        {
            _repoTipoGasto = repoTipoGasto;
        }

        public DTOTipoGasto ObtenerTipoGasto(int id)
        {
            TipoGasto buscado = _repoTipoGasto.FindById(id);
            DTOTipoGasto dto = MapperTipoGasto.FromTipoGastoToDTOTipoGasto(buscado);
            return dto;
        }
    }
}

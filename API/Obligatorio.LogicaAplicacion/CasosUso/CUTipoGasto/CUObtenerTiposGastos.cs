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
    public class CUObtenerTiposGastos : ICUObtenerTiposGastos
    {
        IRepositorioTipoGasto _repoTipoGasto;

        public CUObtenerTiposGastos(IRepositorioTipoGasto repoTipoGasto)
        {
            _repoTipoGasto = repoTipoGasto;
        }

        public List<DTOTipoGasto> ObtenerTiposGastos()
        {
            List<TipoGasto> listTipoGasto = _repoTipoGasto.FindAll();
            List<DTOTipoGasto> listDTO = MapperTipoGasto.ToDTOTipoGastoList(listTipoGasto);
            return listDTO;
        }
    }
}

using Obligatorio.DTOs.DTOsTipoGasto;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperTipoGasto
    {
        public static TipoGasto FromDTOAltaTipoGastoToTipoGasto(DTOAltaTipoGasto dto)
        {
            TipoGasto tg = new TipoGasto();
            tg.Nombre = dto.Nombre;
            tg.Descripcion = dto.Descripcion;
            return tg;
        }

        public static DTOTipoGasto FromTipoGastoToDTOTipoGasto(TipoGasto tg)
        {
            DTOTipoGasto dto = new DTOTipoGasto();
            dto.Id = tg.Id;
            dto.Nombre = tg.Nombre;
            dto.Descripcion = tg.Descripcion;
            return dto;
        }

        public static List<DTOTipoGasto> ToDTOTipoGastoList(List<TipoGasto> listTipoGasto)
        {
            List<DTOTipoGasto> listDTO = new List<DTOTipoGasto>();
            foreach (TipoGasto tg in listTipoGasto)
            {
                listDTO.Add(FromTipoGastoToDTOTipoGasto(tg));
            }
            return listDTO;
        }
    }
}

using Obligatorio.DTOs.DTOsEquipo;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperEquipo
    {
        public static DTOEquipo ToDTOEquipo(Equipo equipo)
        {
            DTOEquipo dto = new DTOEquipo();
            dto.Nombre = equipo.Nombre;
            dto.Id = equipo.Id;
            return dto;
        }

        public static List<DTOEquipo> ToListDTOEquipo(List<Equipo> listaEquipo)
        {
            List<DTOEquipo> listaDTO = new List<DTOEquipo>();
            foreach(Equipo e in listaEquipo)
            {
                DTOEquipo dto = ToDTOEquipo(e);
                listaDTO.Add(dto);
            }
            return listaDTO;
        }
    }
}

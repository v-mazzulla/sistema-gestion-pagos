using Obligatorio.DTOs.DTOsEquipo;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUEquipo
{
    public class CUObtenerEquipos : ICUObtenerEquipos
    {
        private IRepositorioEquipo _repoEquipo;

        public CUObtenerEquipos(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public List<DTOEquipo> ObtenerEquipos()
        {
            List<Equipo> equipos = _repoEquipo.FindAll();
            List<DTOEquipo> listaDTO = MapperEquipo.ToListDTOEquipo(equipos);
            return listaDTO;
        }
    }
}

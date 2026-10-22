using Obligatorio.DTOs.DTOsEquipo;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUEquipo
{
    public class CUEquiposPagoUnicoMayor : ICUEquiposPagoUnicoMayor
    {
        private IRepositorioEquipo _repoEquipo;
        public CUEquiposPagoUnicoMayor(IRepositorioEquipo repoEquipo)
        {
            _repoEquipo = repoEquipo;
        }

        public List<DTOEquipo> ObtenerEquiposConPagoUnicoMayor(int monto)
        {
            List<Equipo> equipos = _repoEquipo.EquiposConPagoUnicoMayor(monto);
            if (equipos is not null && equipos.Count > 0){
                List<DTOEquipo> listaDTO = MapperEquipo.ToListDTOEquipo(equipos);
                return listaDTO;
            }
            else
            {
                throw new NotFoundException("No existen equipos");
            }
        }
    }
}

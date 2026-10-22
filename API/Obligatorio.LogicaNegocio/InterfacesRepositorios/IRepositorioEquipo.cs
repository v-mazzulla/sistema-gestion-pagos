using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEquipo
    {
        void Add(Equipo nuevo);
        Equipo FindById(int id);
        List<Equipo> FindAll();
        void Remove(int id);
        void Update(Equipo actualizado);
        List<Equipo> EquiposConPagoUnicoMayor(int monto);
    }
}

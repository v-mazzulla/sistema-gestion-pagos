using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioRolUsuario
    {
        void Add(RolUsuario nuevo);
        RolUsuario FindById(int id);
        List<RolUsuario> FindAll();
        void Remove(int id);
        void Update(RolUsuario actualizado);
    }
}

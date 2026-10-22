using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario
    {
        void Add(Usuario nuevo);
        Usuario FindById(int id);
        List<Usuario> FindAll();
        Usuario FindByEmail(string email);
        void Remove(int id);
        void Update(Usuario actualizado);
        List<Pago> GetPagosDeUsuario(string email);
    }
}

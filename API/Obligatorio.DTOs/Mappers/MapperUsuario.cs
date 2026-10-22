
using Obligatorio.DTOs.DTOsUsuario;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static DTOUsuario FromUsuarioToDTOUsuario(Usuario u)
        {
            DTOUsuario dto = new DTOUsuario();
            dto.Nombre = u.Nombre;
            dto.Apellido = u.Apellido;
            dto.Email = u.Email;
            dto.Rol = u.Rol.Nombre;
            dto.Equipo = u.Equipo.Nombre;
            return dto;
        }

        public static Usuario FromDTOAltaUsuarioToUsuario(DTOAltaUsuario dto)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            return usuario;
        }

        public static List<DTOUsuario> ToDTOUsuarioList(List<Usuario> listUsuario)
        {
            List<DTOUsuario> listDTO = new List<DTOUsuario>();
            foreach (Usuario u in listUsuario)
            {
                listDTO.Add(FromUsuarioToDTOUsuario(u));
            }

            return listDTO;
        }
    }
}

using Obligatorio.DTOs.DTOsUsuario;
using Obligatorio.DTOs.Mappers;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CULogin : ICULogin
    {
        IRepositorioUsuario _repoUsuario;
        public CULogin(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public DTOUsuario VerificarExistencia(DTOLogin dto)
        {
            Usuario buscado = _repoUsuario.FindByEmail(dto.Email);
            if (buscado is not null)
            {
                if (Crypto.VerificarPasswordConBCrypt(dto.Password, buscado.PasswordHash))
                {
                    return MapperUsuario.FromUsuarioToDTOUsuario(buscado);
                }
            }
            throw new DatosInvalidosException();
        }
    }
}

using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.CustomExceptions.CECompartidas;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUResetearContrasenia : ICUResetearContrasenia
    {
        private IRepositorioUsuario _repoUsuario;
        public CUResetearContrasenia(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }


        public string ResetearContrasenia(string email)
        {
            Usuario usuario = _repoUsuario.FindByEmail(email);

            if (usuario is not null)
            {
                Random random = new Random();
                int numero = random.Next(10000000, 99999999);
                string contraseniaGenerada = numero.ToString();

                usuario.PasswordHash = Crypto.HashPasswordConBCrypt(contraseniaGenerada);
                _repoUsuario.Update(usuario);

                return contraseniaGenerada;
            }
            else
            {
                throw new NotFoundException("Usuario no encontrado");
            }
        }
    }
}

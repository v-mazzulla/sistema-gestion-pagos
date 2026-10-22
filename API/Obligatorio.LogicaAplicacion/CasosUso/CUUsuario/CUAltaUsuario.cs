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
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioRolUsuario _repoRolUsuario;
        private IRepositorioEquipo _repoEquipo;

        public CUAltaUsuario(IRepositorioUsuario repoUsuario, IRepositorioRolUsuario repoRolUsuario, IRepositorioEquipo repoEquipo)
        {
            _repoUsuario = repoUsuario;
            _repoRolUsuario = repoRolUsuario;
            _repoEquipo = repoEquipo;
        }

        public void AltaUsuario(DTOAltaUsuario dto)
        {
            Usuario usuario = MapperUsuario.FromDTOAltaUsuarioToUsuario(dto);
            usuario.Rol = _repoRolUsuario.FindById(dto.IdRolSeleccionado);
            usuario.Equipo = _repoEquipo.FindById(dto.IdEquipoSeleccionado);

            if (string.IsNullOrWhiteSpace(dto.Nombre) || string.IsNullOrWhiteSpace(dto.Apellido))
            {
                throw new DatosInvalidosException("El nombre y apellido son obligatorios");
            }

            string username = GenerarUsername(dto.Nombre, dto.Apellido);
            string email = GenerarEmail(username);

            while (ExisteEmail(email))
            {
                email = GenerarVarianteEmail(dto.Nombre, dto.Apellido);
            }

            usuario.Email = email;

            if (!(string.IsNullOrWhiteSpace(dto.Password)) && dto.Password.Length >= 8)
            {
                usuario.PasswordHash = Crypto.HashPasswordConBCrypt(dto.Password);
            }
            else
            {
                throw new DatosInvalidosException("La contraseña debe tener al menos 8 caracteres");
            }

            usuario.Validar();
            _repoUsuario.Add(usuario);
        }

        public string GenerarUsername(string nombre, string apellido)
        {
            string ret = "";

            if (nombre.Length < 3)
            {
                for (int i = 0; i < nombre.Length; i++)
                {
                    ret += nombre[i];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    ret += nombre[i];
                }
            }

            if (apellido.Length < 3)
            {
                for (int i = 0; i < apellido.Length; i++)
                {
                    ret += apellido[i];
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    ret += apellido[i];
                }
            }

            return ret;
        }

        public string GenerarEmail(string username)
        {
            string email = username;
            
            email += "@laEmpresa.com";

            return email.ToLower();
        }

        public string GenerarVarianteEmail(string nombre, string apellido)
        {
            string username = GenerarUsername(nombre, apellido);
            Random rnd = new Random();
            int nroRandom = rnd.Next(1, 10000);
            username += nroRandom;
            string email = GenerarEmail(username);
            return email;
        }

        //retorna true si el email ya existe
        public bool ExisteEmail(string email)
        {
            return _repoUsuario.FindByEmail(email) != null;
        }
    }
}

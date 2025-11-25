using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class Usuario
    {
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _contrasenia;
        private DateTime _fecha;
        private Equipo _perteneceEquipo;
        private RolUsuario _rol;

        public string Nombre { get { return _nombre; } }
        public string Apellido { get { return _apellido; } }
        public string Email { get { return _email; } }
        public string Contrasenia { get { return _contrasenia; } }
        public RolUsuario Rol { get; set; }

        public DateTime Fecha { get { return _fecha; } }
        public Equipo PerteneceEquipo { get { return _perteneceEquipo; } }

        public Usuario(string nombre, string apellido, string contrasenia, DateTime fecha ,Equipo perteneceEquipo ,RolUsuario rol  )
        {
            _nombre = nombre;
            _apellido = apellido;
            _contrasenia = contrasenia;
            _fecha = fecha;
            _email = CrearEmail(nombre, apellido);
            _perteneceEquipo = perteneceEquipo;
            _rol = rol;
        }

        public string CrearEmail(string _nombre, string _apellido)
        {
            string dominio = "@laempresa.com";
            string nombreEmail ;
            string apellidoEmail;

            if (_nombre.Length > 3 )
            {
                nombreEmail = _nombre.Substring(0, 3).ToLower();
            }
            else
            {
                nombreEmail = _nombre.ToLower();
            }
            if (_apellido.Length >3)
            {
                apellidoEmail = _apellido.Substring(0, 3).ToLower();
            }
            else
            {
                apellidoEmail = _apellido.ToLower();
            }
            return nombreEmail + apellidoEmail + dominio;

        }

        public void validar()
        {
            if (_contrasenia.Length < 8)
            {
                throw new Exception("La contrasenia debe tener al menos 8 caracteres");
            }
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre no puede estar vacio");
            }
            if (string.IsNullOrEmpty(_apellido))
            {
                throw new Exception("El Apellido no puede estar vacio");
            }
        }
        public void ActualizarEmail(string nuevoEmail)
        {
            _email = nuevoEmail;
        }
    }
}

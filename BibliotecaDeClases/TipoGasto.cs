using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class TipoGasto
    {
        private string _nombre;
        private string _descripcion;

        public string Nombre { get { return _nombre; } }
        public string Descripcion { get { return _descripcion; } }
        public TipoGasto( string nombre, string descripcion)
        {
            _nombre = nombre;
            _descripcion = descripcion;
        }
        public void validar()
        {
            if (string.IsNullOrEmpty(_nombre) )
            {
                throw new Exception("El nombre no puede estar vacio");
            }
            if (string.IsNullOrEmpty(_descripcion) )
            {
                throw new Exception("La descripcion no puede estar vacia");
            }
        }

    }
}

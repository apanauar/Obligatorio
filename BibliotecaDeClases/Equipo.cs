using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class Equipo

    {
        private int _id;
        private string _nombre;

       public int Id { get { return _id; } }
       public string Nombre { get { return _nombre; } }
    
       public Equipo( string nombre , int id )
          {
            _id = id;
            _nombre = nombre;
          }

        public void validar()
        {
            if (string.IsNullOrEmpty(_nombre) )
            {
                throw new Exception("El nombre del equipo no puede estar vacio");
            }
            if (_id <= 0)
            {
                throw new Exception("El id del equipo debe ser mayor a 0");
            }

        }

    }

   
}

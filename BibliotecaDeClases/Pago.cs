using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public abstract class Pago 
    {
        private static int _ultimoId = 0;
        private int _id;
        private MetodoDePago _metodoPago;
        private TipoGasto _gastoAsociado;
        private Usuario _usuarioAsociado;
        private string _descripcion;
        

         public int Id { get { return _id; } }
         public MetodoDePago MetodoPago { get { return _metodoPago; } }
         public TipoGasto GastoAsociado { get { return _gastoAsociado; } }
         public Usuario UsuarioAsociado { get { return _usuarioAsociado; } }
         public string Descripcion { get { return _descripcion; } }
         public Pago( MetodoDePago metodoPago, TipoGasto gastoAsociado, Usuario usuarioAsociado, string descripcion) 
        {
             _ultimoId++;
             _id = _ultimoId;
             _metodoPago = metodoPago;
             _gastoAsociado = gastoAsociado;
             _usuarioAsociado = usuarioAsociado;
             _descripcion = descripcion;
         }

         public abstract decimal MontoTotal();
        public virtual void Validar()
        {
            if (_usuarioAsociado == null)
            {
                throw new Exception("El usuario asociado no puede ser nulo.");
            }

        }
         public override  string ToString()
         {
            return $"Ìd: {_id} " +
                   $"Metodo de Pago: {_metodoPago}";
                   
         }

    }

}

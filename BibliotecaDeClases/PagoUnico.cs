using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class PagoUnico: Pago
    {
        private DateTime _fechaPago;
        private int _numeroRecibo;
        private decimal _montoPago;

        public DateTime FechaPago { get { return _fechaPago; } }
        public int NumeroRecibo { get { return _numeroRecibo; } }
        public decimal MontoPago { get { return _montoPago; } }
       

        public PagoUnico(DateTime fechaPago, decimal montoPago, MetodoDePago metodoPago, TipoGasto gastoAsociado, Usuario usuarioAsociado, string descripcion, int numeroRecibo) 
            : base( metodoPago,gastoAsociado, usuarioAsociado, descripcion)
        {
            _numeroRecibo = numeroRecibo;
            _fechaPago = fechaPago;
            _montoPago = montoPago;
        }

        public override decimal MontoTotal()
        {
            return _montoPago;
        }
        public override void Validar()
        {
            base.Validar();
            if (_montoPago <= 0)
            {
                throw new Exception("El monto del pago debe ser mayor a 0");
            }
            if (_numeroRecibo <= 0)
            {
                throw new Exception("El numero del recibo debe ser mayor a 0");
            }
        }
        public override string ToString()
        {

            return base.ToString() + $"  NumeroPago {_numeroRecibo}" + $"   Monto de pago:{_montoPago}" + $"   Fecha Pago{_fechaPago}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class PagoRecurrente : Pago
    {
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private decimal _montoPago;
        private static int _ultimoId = 0;
        private int _id;
        private string _estado;
        private bool _tieneFin;



        public DateTime FechaInicio { get { return _fechaInicio; } }
        public DateTime FechaFin { get { return _fechaFin; } }
        public string Estado { get { return _estado; } }
        public decimal MontoPago { get { return _montoPago; } }


        public PagoRecurrente(DateTime fechaInicio, DateTime fechaFin, decimal montoPago, MetodoDePago metodoPago, TipoGasto gastoAsociado, Usuario usuarioAsociado, string descripcion, bool tieneFin)
            : base(metodoPago, gastoAsociado, usuarioAsociado, descripcion)
        {
            _ultimoId++;
            _id = _ultimoId;
            _fechaInicio = fechaInicio;
            _fechaFin = fechaFin;
            _montoPago = montoPago;
            _tieneFin = tieneFin;
            _estado =  CalcularEstado(tieneFin);
        }

        public override decimal MontoTotal()
        {
            TimeSpan cantidadTiempo = _fechaFin - _fechaInicio;
            int meses = cantidadTiempo.Days / 30;
            return meses * _montoPago;
        }

        public override void Validar()
        {
            base.Validar();
            if (_tieneFin)
            {
                if (_fechaFin < _fechaInicio)
                {
                    throw new Exception("La fecha de fin no puede ser menor a la fecha de inicio");
                }
            }
            else
            {
                if (_fechaFin != DateTime.MinValue || _fechaInicio == DateTime.MinValue)
                {
                    throw new Exception("La fecha fin o de inicio esta mal inicializada ");
                }
            }

            if (_montoPago <= 0)
            {
                throw new Exception("El monto del pago debe ser mayor a 0");
            }
        }
        public string CalcularEstado(bool _tieneFin)
        {
            if (_tieneFin)
            {
                if (_fechaFin <= DateTime.Now)
                {
                    _estado = "Finalizado";
                    
                }
                else
                {
                    _estado = "Pendiente";
                }
            }
            else
            {
                _estado = "Recurrente";
            }
            return _estado;

        }
        public int cantidadCuotas()
        {
            TimeSpan cantidadTiempo = _fechaFin - DateTime.Now;
            int cuotas = cantidadTiempo.Days / 30;
            return cuotas;

        }

        public override string ToString()
        {

            if (_estado == "Recurrente")
            {
                return base.ToString() +  $"Estado :{_estado}";

            }
            else if (_estado == "Finalizado")
            {
                return base.ToString()  + $"   Estado : {_estado}";
            }
            else{
                return base.ToString()  + $"Cantidad de Cuotas Restantes: {cantidadCuotas()}";
            }
        } 
    } 
}



using System;
using static BibliotecaDeClases.Pago;
using BibliotecaDeClases;
namespace Obligatorio
{
    internal class Program
    {

        private static Sistema _sistema = Sistema.instancia;

        static void Main(string[] args)
        {
            try
            {

                _sistema.PrecargarDatos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al precargar datos: {ex.Message}");
                Console.WriteLine("Presione una tecla para salir...");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Obligatorio");
                Console.WriteLine("Presione 1 para listar todos los usuarios");
                Console.WriteLine("Presione 2 para hacer un alta de usuario");
                Console.WriteLine("Presione 3 para mostrar los usuarios por equipo");
                Console.WriteLine("Presione 4 para mostrar los pagos realizado por un usuario");
                Console.WriteLine("Presione 0 para salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        _sistema.ListarUsuarios();
                        Console.WriteLine("Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        verificarDatosAlta();
                        Console.WriteLine("Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        ValidarNombreEquipo();
                        Console.WriteLine("Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        VerificarDatosPago();
                        Console.WriteLine("Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case "0":
                        Console.WriteLine("Programa finalizado");
                        return;
                }
            }





        }
        static void verificarDatosAlta()
        {
            string nombre;
            string apellido;
            string contrasenia;
            while (true)
            {
                Console.WriteLine("ingrese Su Nombre");
                string nombreV = (Console.ReadLine() ?? "").Trim();
                if (string.IsNullOrEmpty(nombreV))
                {
                    Console.WriteLine("El nombre no puede estar vacio");
                }
                else
                {
                    nombre = nombreV;
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("ingrese Su Apellido");
                string apellidoV = (Console.ReadLine() ?? "").Trim();
                if (string.IsNullOrEmpty(apellidoV))
                {
                    Console.WriteLine("El apellido no puede estar vacio");
                }
                else
                {
                    apellido = apellidoV;
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("ingrese Su Contrasenia");
                string contraseniaV = (Console.ReadLine() ?? "").Trim();
                if (string.IsNullOrEmpty(contraseniaV) || contraseniaV.Length < 8)
                {
                    Console.WriteLine("La contrasenia no puede estar vacia");
                }
                else
                {
                    contrasenia = contraseniaV;
                    break;
                }
            }
            int idEquipo;
            while (true)
            {
                _sistema.MostrarEquipos();
                Console.WriteLine("Ingrese el id del equipo al que pertenece: ");
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out idEquipo))
                    if (idEquipo >= 1 && idEquipo <= 4)
                    {

                        break;
                    }

                    else
                    {
                        Console.WriteLine("El id de el equipo no pertenece a ningun equipo");
                    }
            }
            _sistema.crearUsuario(nombre, apellido, contrasenia, idEquipo);
        }
        static void VerificarDatosPago()
        {
            string mail;
            while (true)
            {
                Console.WriteLine("ingrese Su Mail");
                string mailV = (Console.ReadLine() ?? "").Trim();
                if (string.IsNullOrEmpty(mailV))
                {
                    Console.WriteLine("El mail no puede estar vacio");
                }
                else
                {
                    mail = mailV;
                    break;
                }

            }
            _sistema.MostrarPagosPorUsuario(mail);

        }
        static void ValidarNombreEquipo()
        {
            string nombre;
            while (true)
            {
                Console.WriteLine("ingrese el nombre del equipo");
                string nombreV = (Console.ReadLine() ?? "").Trim();
                if (string.IsNullOrEmpty(nombreV))
                {
                    Console.WriteLine("El nombre no puede estar vacio");
                }
                else
                {
                    nombre = nombreV;
                    break;
                }
            }
            _sistema.MostrarUsuariosPorEquipo(nombre);
        }
    }
}

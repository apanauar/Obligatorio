using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static BibliotecaDeClases.Pago;

namespace BibliotecaDeClases
{
    public class Sistema
    {


        #region singleton
        private static Sistema _instancia;

        public static Sistema instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }
        #endregion

        public List<Usuario> _usuarios = new List<Usuario> ();
        public List<TipoGasto> _tiposGasto = new List<TipoGasto>();
        public List<Equipo> _equipos = new List<Equipo>();
        public List<Pago> _pagos = new List<Pago>();
         public void PrecargarDatos()
        {
            // ===== EQUIPOS =====
            Equipo desarrollo = new Equipo("Desarrollo",1);
            Equipo marketing = new Equipo("Marketing",2);
            Equipo ventas = new Equipo("Ventas",3);
            Equipo soporte = new Equipo("Soporte",4);

            AltaEquipo(desarrollo);
            AltaEquipo(marketing);
            AltaEquipo(ventas);
            AltaEquipo(soporte);



            // ===== USUARIOS =====
            AltaUsuario(new Usuario("Juan", "Pérez", "clave1234", new DateTime(2022, 5, 10), desarrollo ,RolUsuario.gerente));
            AltaUsuario(new Usuario("María", "Gómez", "segura5678", new DateTime(2023, 1, 15), ventas , RolUsuario.cliente));
            AltaUsuario(new Usuario("Luis", "Rodríguez", "contra999", new DateTime(2021, 7, 3), soporte, RolUsuario.gerente));
            AltaUsuario(new Usuario("Laura", "Fernández", "pass4321", new DateTime(2022, 3, 12), desarrollo, RolUsuario.cliente));
            AltaUsuario(new Usuario("Pedro", "López", "pass6789", new DateTime(2024, 2, 8), marketing, RolUsuario.gerente));
            AltaUsuario(new Usuario("Ana", "Martínez", "clave0000", new DateTime(2021, 11, 23), ventas, RolUsuario.gerente));
            AltaUsuario(new Usuario("Sofía", "Torres", "segura2024", new DateTime(2023, 8, 5), soporte, RolUsuario.cliente));
            AltaUsuario(new Usuario("Diego", "Castro", "diegopass", new DateTime(2024, 5, 20), desarrollo, RolUsuario.cliente));
            AltaUsuario(new Usuario("Valentina", "Suárez", "valenpass1", new DateTime(2022, 12, 1), ventas, RolUsuario.cliente));
            AltaUsuario(new Usuario("Camila", "Ruiz", "camiRuiz2", new DateTime(2024, 4, 18), marketing, RolUsuario.cliente));
            AltaUsuario(new Usuario("Tomás", "Núñez", "tompass12", new DateTime(2021, 9, 9), ventas, RolUsuario.cliente));
            AltaUsuario(new Usuario("Martín", "Silva", "martin789", new DateTime(2023, 6, 25), soporte, RolUsuario.cliente));
            AltaUsuario(new Usuario("Lucía", "Pereira", "luciapass", new DateTime(2023, 10, 5), marketing, RolUsuario.cliente));
            AltaUsuario(new Usuario("Andrés", "González", "andreskey", new DateTime(2022, 2, 19), desarrollo, RolUsuario.cliente));
            AltaUsuario(new Usuario("Paula", "Santos", "paulaPASS", new DateTime(2022, 8, 14), desarrollo, RolUsuario.cliente));
            AltaUsuario(new Usuario("Bruno", "Méndez", "brunopass", new DateTime(2024, 1, 30), marketing, RolUsuario.cliente));
            AltaUsuario(new Usuario("Carla", "Herrera", "carla321", new DateTime(2022, 5, 15), ventas, RolUsuario.cliente));
            AltaUsuario(new Usuario("Ignacio", "Vega", "ignacio88", new DateTime(2023, 9, 1), soporte, RolUsuario.cliente));
            AltaUsuario(new Usuario("Florencia", "Ramos", "flor4567", new DateTime(2022, 12, 20), soporte, RolUsuario.cliente));
            AltaUsuario(new Usuario("Emilia", "Acosta", "emilia123", new DateTime(2024, 3, 7), marketing, RolUsuario.cliente));
            AltaUsuario(new Usuario("Nicolás", "Morales", "nicolas22", new DateTime(2021, 4, 12), desarrollo, RolUsuario.cliente));
            AltaUsuario(new Usuario("Daniela", "Luna", "danielapass", new DateTime(2023, 7, 9), soporte, RolUsuario.cliente));

            // ===== TIPOS DE GASTO =====
            TipoGasto auto = new TipoGasto("Auto", "Gastos del vehículo (nafta, seguro, reparaciones)");
            TipoGasto afters = new TipoGasto("Afters", "Salidas grupales del equipo");
            TipoGasto comida = new TipoGasto("Comida", "Almuerzos, cenas, cafetería");
            TipoGasto transporte = new TipoGasto("Transporte", "Movilidad: bus, Uber, etc.");
            TipoGasto equipos = new TipoGasto("Equipos", "Compra de hardware o periféricos");
            TipoGasto software = new TipoGasto("Software", "Licencias, suscripciones, herramientas");
            TipoGasto oficina = new TipoGasto("Oficina", "Artículos y papelería");
            TipoGasto internet = new TipoGasto("Internet", "Pagos mensuales de conexión");
            TipoGasto eventos = new TipoGasto("Eventos", "Capacitaciones y conferencias");
            TipoGasto servicios = new TipoGasto("Servicios", "Mantenimiento o limpieza");

            AltaTipoGasto(auto);
            AltaTipoGasto(afters);
            AltaTipoGasto(comida);
            AltaTipoGasto(transporte);
            AltaTipoGasto(equipos);
            AltaTipoGasto(software);
            AltaTipoGasto(oficina);
            AltaTipoGasto(internet);
            AltaTipoGasto(eventos);
            AltaTipoGasto(servicios);

            // ===== PAGOS =====


            AltaPago(new PagoRecurrente(new DateTime(2024, 1, 1), new DateTime(2024, 6, 30), 500, MetodoDePago.EFECTIVO, servicios, BuscarUsuario("juaper@laempresa.com"), "Mantenimiento mensual", true));

            AltaPago(new PagoRecurrente(new DateTime(2023, 10, 1), new DateTime(2025, 6, 3), 200, MetodoDePago.DEBITO, servicios, BuscarUsuario("margom@laempresa.com"), "Antel fibra", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 3, 10), DateTime.MinValue, 2000, MetodoDePago.CREDITO, equipos, BuscarUsuario("luirod@laempresa.com"), "Notebook en cuotas", false));

            AltaPago(new PagoRecurrente(new DateTime(2024, 2, 1), new DateTime(2024, 12, 21), 300, MetodoDePago.DEBITO, internet, BuscarUsuario("laufer@laempresa.com"), "Fibra hogar", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 4, 1), DateTime.MinValue, 1500, MetodoDePago.EFECTIVO, servicios, BuscarUsuario("pedlop@laempresa.com"), "Mantenimiento oficina", false));

            AltaPago(new PagoRecurrente(new DateTime(2024, 1, 1), new DateTime(2024, 3, 12), 2500, MetodoDePago.CREDITO, equipos, BuscarUsuario("anamar@laempresa.com"), "Monitor nuevo", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 5, 1), DateTime.MinValue, 700, MetodoDePago.DEBITO, software, BuscarUsuario("softor@laempresa.com"), "Spotify Familiar", false));

            AltaPago(new PagoRecurrente(new DateTime(2023, 9, 1), new DateTime(2024, 10, 1), 1000, MetodoDePago.CREDITO, internet, BuscarUsuario("diecas@laempresa.com"), "Internet Empresa", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 6, 1), DateTime.MinValue, 2500, MetodoDePago.CREDITO, eventos, BuscarUsuario("valsua@laempresa.com"), "Curso UX online", false));

            AltaPago(new PagoRecurrente(new DateTime(2024, 1, 1), new DateTime(2024, 5, 23), 1800, MetodoDePago.DEBITO, servicios, BuscarUsuario("camrui@laempresa.com"), "Limpieza mensual", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 2, 1), new DateTime(2025, 12, 1), 1200, MetodoDePago.CREDITO, software, BuscarUsuario("tomnun@laempresa.com"), "Adobe Creative Cloud", true));

            AltaPago(new PagoRecurrente(new DateTime(2023, 11, 15), new DateTime(2025, 5, 15), 1800, MetodoDePago.EFECTIVO, servicios, BuscarUsuario("marsil@laempresa.com"), "Seguridad del local", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 3, 10), new DateTime(2024, 8, 10), 700, MetodoDePago.DEBITO, internet, BuscarUsuario("lucper@laempresa.com"), "Plan fibra óptica", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 5, 1), new DateTime(2024, 11, 1), 2300, MetodoDePago.CREDITO, equipos, BuscarUsuario("andgon@laempresa.com"), "PC escritorio nueva", true));

            AltaPago(new PagoRecurrente(new DateTime(2023, 12, 1), new DateTime(2025, 12, 1), 800, MetodoDePago.DEBITO, servicios, BuscarUsuario("pausan@laempresa.com"), "Servicio limpieza", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 1, 1), new DateTime(2024, 5, 1), 950, MetodoDePago.CREDITO, software, BuscarUsuario("brumen@laempresa.com"), "Canva Pro", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 6, 1), DateTime.MinValue, 1600, MetodoDePago.DEBITO, internet, BuscarUsuario("carher@laempresa.com"), "Internet oficina central", false));

            AltaPago(new PagoRecurrente(new DateTime(2024, 2, 1), DateTime.MinValue, 1400, MetodoDePago.EFECTIVO, equipos, BuscarUsuario("ignveg@laempresa.com"), "Tablet logística", false));

            AltaPago(new PagoRecurrente(new DateTime(2023, 9, 1), DateTime.MinValue, 600, MetodoDePago.DEBITO, servicios, BuscarUsuario("floram@laempresa.com"), "Mantenimiento software", false));

            AltaPago(new PagoRecurrente(new DateTime(2024, 3, 1), DateTime.MinValue, 2500, MetodoDePago.CREDITO, eventos, BuscarUsuario("emiaco@laempresa.com"), "Curso Marketing Digital", false));

            AltaPago(new PagoRecurrente(new DateTime(2024, 4, 1), new DateTime(2025, 12, 1), 1800, MetodoDePago.EFECTIVO, servicios, BuscarUsuario("nicmor@laempresa.com"), "Asesoría contable", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 5, 15), new DateTime(2024, 11, 15), 1300, MetodoDePago.CREDITO, software, BuscarUsuario("danlun@laempresa.com"), "ChatGPT Plus", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 7, 1), DateTime.MinValue,500, MetodoDePago.DEBITO, equipos, BuscarUsuario("juaper@laempresa.com"), "Laptop nueva", false ));

            AltaPago(new PagoRecurrente(new DateTime(2023, 10, 1), new DateTime(2025, 4, 1), 900, MetodoDePago.EFECTIVO, internet, BuscarUsuario("margom@laempresa.com"), "Fibra hogar secundaria", true));

            AltaPago(new PagoRecurrente(new DateTime(2024, 1, 5), new DateTime(2025, 1, 5), 2800, MetodoDePago.DEBITO, servicios, BuscarUsuario("luirod@laempresa.com"), "Mantenimiento anual equipos", true));

            AltaPago(new PagoUnico(new DateTime(2024, 5, 10), 200, MetodoDePago.DEBITO, auto, BuscarUsuario("diecas@laempresa.com"), "Pan", 1));

            // 17 ÚNICOS
            AltaPago(new PagoUnico(new DateTime(2024, 5, 10), 200, MetodoDePago.DEBITO, auto, BuscarUsuario("diecas@laempresa.com"), "Pan", 1));
            AltaPago(new PagoUnico(new DateTime(2024, 6, 02), 950, MetodoDePago.CREDITO, comida, BuscarUsuario("juaper@laempresa.com"), "Almuerzo con cliente",2));
            AltaPago(new PagoUnico(new DateTime(2024, 4, 18), 480, MetodoDePago.EFECTIVO, transporte, BuscarUsuario("margom@laempresa.com"), "Peajes Ruta Interbalnearia",3));
            AltaPago(new PagoUnico(new DateTime(2024, 7, 05), 3600, MetodoDePago.CREDITO, equipos, BuscarUsuario("luirod@laempresa.com"), "Figma anual",4));
            AltaPago(new PagoUnico(new DateTime(2024, 3, 22), 1250, MetodoDePago.DEBITO, software, BuscarUsuario("laufer@laempresa.com"), "Mouse ergonómico",5));
            AltaPago(new PagoUnico(new DateTime(2024, 8, 14), 2100, MetodoDePago.EFECTIVO, oficina, BuscarUsuario("pedlop@laempresa.com"), "Traslado a cliente",6));
            AltaPago(new PagoUnico(new DateTime(2024, 2, 28), 5400, MetodoDePago.CREDITO, internet, BuscarUsuario("anamar@laempresa.com"), "Teclado mecánico",7));
            AltaPago(new PagoUnico(new DateTime(2024, 9, 03), 780, MetodoDePago.DEBITO, oficina, BuscarUsuario("softor@laempresa.com"), "Insumos (papel, café)",8));
            AltaPago(new PagoUnico(new DateTime(2024, 1, 19), 3200, MetodoDePago.CREDITO, afters, BuscarUsuario("valsua@laempresa.com"), "After equipo",9));
            AltaPago(new PagoUnico(new DateTime(2024, 5, 27), 950, MetodoDePago.EFECTIVO, comida, BuscarUsuario("camrui@laempresa.com"), "Cena con proveedor",10));
            AltaPago(new PagoUnico(new DateTime(2024, 6, 30), 1750, MetodoDePago.DEBITO, afters, BuscarUsuario("tomnun@laempresa.com"), "Hotel por capacitación",11));
            AltaPago(new PagoUnico(new DateTime(2024, 4, 05), 420, MetodoDePago.EFECTIVO, internet, BuscarUsuario("marsil@laempresa.com"), "Taxi aeropuerto",12));
            AltaPago(new PagoUnico(new DateTime(2024, 7, 21), 1100, MetodoDePago.CREDITO, eventos, BuscarUsuario("lucper@laempresa.com"), "Entrada a conferencia",13));
            AltaPago(new PagoUnico(new DateTime(2024, 3, 11), 3900, MetodoDePago.CREDITO, afters, BuscarUsuario("andgon@laempresa.com"), "Curso SEO",14));
            AltaPago(new PagoUnico(new DateTime(2024, 8, 08), 860, MetodoDePago.DEBITO, oficina, BuscarUsuario("pausan@laempresa.com"), "Sillas oficina",15));
            AltaPago(new PagoUnico(new DateTime(2024, 2, 07), 2500, MetodoDePago.EFECTIVO, eventos, BuscarUsuario("brumen@laempresa.com"), "Alquiler de stand",16));
            AltaPago(new PagoUnico(new DateTime(2024, 9, 12), 1320, MetodoDePago.DEBITO, oficina, BuscarUsuario("carher@laempresa.com"), "Suite analítica mensual",17));


        }


        public void AltaUsuario(Usuario usuario)

        {
            string emailBase = usuario.Email;
            string nuevoEmail = emailBase;
            int contador = 1;
            bool existe = true;

            while (existe){ 
                existe = false;
                foreach (Usuario unU in _usuarios)
            {
                if (unU.Email.ToLower() == nuevoEmail.ToLower())
                {
                    int indexArroba = emailBase.IndexOf('@');
                    string parteAntes = emailBase.Substring(0, indexArroba);
                    string dominio = emailBase.Substring(indexArroba);
                    nuevoEmail = parteAntes + contador + dominio;
                    contador ++;
                    existe = true;
                    break;
                 }
            }

            }
            usuario.ActualizarEmail(nuevoEmail);
            try
            { usuario.validar(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _usuarios.Add(usuario);
        }

        public void AltaTipoGasto(TipoGasto tipoGasto)
        {
            try { 
                tipoGasto.validar(); 
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _tiposGasto.Add(tipoGasto);
        }
      
        public void AltaEquipo(Equipo equipo)
        {
            try
            {
                equipo.validar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                _equipos.Add(equipo);
        }
        public void AltaPago(Pago pago)
        {
            try
            {
                pago.Validar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _pagos.Add(pago);
        }
     

        public Usuario BuscarUsuario(string email)
        {
            Usuario encontrarUsuario = null;
            foreach (Usuario unU in _usuarios)
            {
                if (unU.Email.ToLower() == email.ToLower())
                {
                    encontrarUsuario = unU;
                }
                
            }
            return encontrarUsuario;
        }
        public List<Usuario> ObtenerMiembrosEquipo(Usuario gerente)
        {
            List<Usuario> miembros = new List<Usuario>();

            foreach (Usuario u in _usuarios)
            {
                if (u.PerteneceEquipo == gerente.PerteneceEquipo && u != gerente)
                {
                    miembros.Add(u);
                }
            }

            return miembros;
        }
        public Usuario BuscarUsuarioPorEmailYContrasenia(string email, string contrasenia)
        {
            Usuario encontrarUsuario = null;
            foreach (Usuario unU in _usuarios)
            {
                if (unU.Email.ToLower() == email.ToLower() && unU.Contrasenia == contrasenia)
                {
                    encontrarUsuario = unU;
                    break;
                }
            }
            return encontrarUsuario;
        }

        public void ListarUsuarios()
        {
            Console.WriteLine("LISTADO DE USUARIOS");

            if (_usuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados.");
                return;
            }

            foreach (Usuario unU in _usuarios)
            {
                Console.WriteLine($"Nombre: {unU.Nombre} {unU.Apellido}");
                Console.WriteLine($"Email: {unU.Email}");
                Console.WriteLine($"Equipo: {unU.PerteneceEquipo.Nombre}");
                Console.WriteLine("------------------------------------");
            }
        }


        public void MostrarPagosPorUsuario(string email)
        {
            
            Console.WriteLine("LISTADO DE PAGOS POR USUARIO");

            Usuario usuarioBuscado = null;
            foreach (Usuario unU in _usuarios)
            {
                if (unU.Email.ToLower() == email.ToLower())
                {
                    usuarioBuscado = unU;
                    break;
                }
            }

            if (usuarioBuscado == null)
            {
                Console.WriteLine("No se encontró ningún usuario con ese email.");
                return;
            }

            Console.WriteLine($"Pagos realizados por {usuarioBuscado.Nombre} {usuarioBuscado.Apellido} ({usuarioBuscado.Email})");
            Console.WriteLine("------------------------------------------------------");

            bool tienePagos = false;

            foreach (Pago unP in _pagos)
            {
                if (unP.UsuarioAsociado != null &&
                    unP.UsuarioAsociado.Email.ToLower() == email.ToLower())
                {
                    Console.WriteLine(unP.ToString());
                    Console.WriteLine("------------------------------------------------------");
                    tienePagos = true;
                }

            }


            if (!tienePagos)
            {
                Console.WriteLine("Este usuario no tiene pagos registrados.");
            }

        }



        public void MostrarEquipos()
        {
            Console.WriteLine(" EQUIPOS DISPONIBLES");
            foreach (Equipo equipo in _equipos)
            {
                Console.WriteLine($"{equipo.Nombre} ,{equipo.Id}");
            }
            Console.WriteLine();
        }
        public void crearUsuario(string nombre , string apellido , string contrasenia , int idEquipo , RolUsuario rol)
        {
            DateTime fecha = DateTime.Now;
            
            Equipo equipoSeleccionado = null;
            foreach (Equipo equipo in _equipos)
            {
                if (equipo.Id == idEquipo)
                {
                    equipoSeleccionado = equipo;
                }
            }
            Usuario usu1 = new Usuario(nombre, apellido, contrasenia, fecha, equipoSeleccionado , rol);
            try
            {
                AltaUsuario(usu1);
                Console.WriteLine($" Alta : {usu1.Nombre} , {usu1.Apellido} ,   {usu1.Email},  {usu1.PerteneceEquipo.Nombre}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("El usuario no se pudo crear correctamente");
            }
           
        }
        



        public void MostrarUsuariosPorEquipo(string nombreEquipo)
        {
            Console.WriteLine(" LISTADO DE USUARIOS POR EQUIPO ");

            Equipo equipoBuscado = null;
            foreach (Equipo unE in _equipos)
            {
                if (unE.Nombre.ToLower() == nombreEquipo.ToLower())
                {
                    equipoBuscado = unE;
                    break;
                }
            }

            if (equipoBuscado == null)
            {
                Console.WriteLine("No se encontró ningún equipo con ese nombre.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Usuarios que pertenecen al equipo {equipoBuscado.Nombre}:");
            Console.WriteLine("------------------------------------------------------");

            bool hayUsuarios = false;

            foreach (Usuario unU in _usuarios)
            {
                if (unU.PerteneceEquipo != null && unU.PerteneceEquipo.Nombre.ToLower() == nombreEquipo.ToLower())
                   
                {
                    Console.WriteLine($"- {unU.Nombre} {unU.Apellido} ({unU.Email})");
                    hayUsuarios = true;
                }
            }

            if (!hayUsuarios)
            {
                Console.WriteLine("No hay usuarios registrados en este equipo.");
            }
        }










    }
}

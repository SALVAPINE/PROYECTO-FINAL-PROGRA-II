using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Transactions;
using System.Windows.Forms;
using Datos;
using Entidad;
using Negocio;
using SistemaPublicidad.Formularios;

internal static class Program
{
    static int comprobaciones;
    static readonly List<int> usuariosCreados = new List<int>();
    static int clienteCreado;
    static readonly UsuarioNegocio usuarios = new UsuarioNegocio();
    static readonly string clave = Guid.NewGuid().ToString("N") + "aA7!";

    [STAThread]
    static int Main()
    {
        try
        {
            VerificarEsquema();
            var seguridad = typeof(UsuarioDatos).Assembly.GetType("Datos.SeguridadClaves");
            var crear = seguridad.GetMethod("Crear", BindingFlags.NonPublic | BindingFlags.Static);
            var verificar = seguridad.GetMethod("Verificar", BindingFlags.NonPublic | BindingFlags.Static);
            string hash = (string)crear.Invoke(null, new object[] { clave });
            Afirmar(hash != (string)crear.Invoke(null, new object[] { clave }), "Sal distinta para la misma contraseña");
            Afirmar((bool)verificar.Invoke(null, new object[] { clave, hash }), "Hash válido");
            Afirmar(!(bool)verificar.Invoke(null, new object[] { clave + "x", hash }), "Contraseña incorrecta rechazada");
            Afirmar(!(bool)verificar.Invoke(null, new object[] { clave, "PBKDF2-SHA256$invalido" }), "Hash malformado rechazado");
            foreach (string rol in RolNegocio.TiposUsuario)
            {
                string nombre = "prueba09_" + Guid.NewGuid().ToString("N").Substring(0, 18);
                usuarios.Insertar(new Usuario { CodigoSucursal = 1, NombreUsuario = nombre, Clave = clave,
                    FechaCreacion = DateTime.Now, TipoUsuario = rol, Estado = true });
                Usuario cuenta = usuarios.Listar().Single(x => x.NombreUsuario == nombre);
                usuariosCreados.Add(cuenta.CodigoUsuario);
                Afirmar(cuenta.Clave == "", "Las listas no exponen contraseñas: " + rol);
                Afirmar(usuarios.Autenticar(nombre, clave)?.TipoUsuario == rol, "Login: " + rol);
                if (rol != "Administrador")
                {
                    bool denegado = false;
                    try { new RolNegocio().Listar(); } catch (UnauthorizedAccessException) { denegado = true; }
                    Afirmar(denegado, "Gestión de roles denegada a " + rol);
                    Afirmar(!new RolNegocio().ListarModulosPermitidos(rol).Contains("Roles"), "Roles fuera del menú de " + rol);
                }
                usuarios.Actualizar(cuenta); // clave vacía conserva el hash.
                Afirmar(usuarios.Autenticar(nombre, clave) != null, "Editar sin cambiar contraseña: " + rol);
                if (rol == "Administrador")
                {
                    cuenta.Clave = clave + "nueva";
                    usuarios.Actualizar(cuenta);
                    Afirmar(usuarios.Autenticar(nombre, clave) == null, "Restablecer contraseña invalida la anterior");
                    Afirmar(usuarios.Autenticar(nombre, cuenta.Clave) != null, "Restablecer contraseña permite la nueva");
                    cuenta.Clave = clave;
                    usuarios.Actualizar(cuenta);
                    cuenta.Clave = "";
                }
                cuenta.Estado = false;
                usuarios.Actualizar(cuenta);
                Afirmar(usuarios.Autenticar(nombre, clave) == null, "Cuenta inactiva rechazada: " + rol);
                cuenta.Estado = true;
                usuarios.Actualizar(cuenta);
            }
            Afirmar(usuarios.Autenticar("no_existe_" + Guid.NewGuid().ToString("N"), clave) == null, "Cuenta inexistente rechazada");
            Usuario admin = usuarios.Listar().First(x => usuariosCreados.Contains(x.CodigoUsuario) && x.TipoUsuario == "Administrador");
            Afirmar(usuarios.Autenticar(admin.NombreUsuario, clave) != null, "Sesión de prueba administrativa");
            Afirmar(new RolNegocio().Listar().Count > 0, "Administrador consulta permisos reales");
            Afirmar(new RolNegocio().ListarModulosPermitidos("rol_inexistente").SequenceEqual(new[] { "Inicio" }), "Rol desconocido sin accesos de gestión");
            ProbarPermisos();
            ProbarDpi();
            ProbarRecordarUsuario();
            ProbarFormularios(admin.NombreUsuario);
            Console.WriteLine("OK: " + comprobaciones + " comprobaciones de integración.");
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
        finally
        {
            if (clienteCreado > 0) new ClienteDatos().Eliminar(clienteCreado);
            foreach (int codigo in usuariosCreados) new UsuarioDatos().Eliminar(codigo);
            SesionActual.Cerrar();
        }
    }

    static void VerificarEsquema()
    {
        using (var conexion = ConexionDatos.CrearConexion())
        {
            conexion.Open();
            using (var comando = new SqlCommand(@"SELECT
                (SELECT COUNT(*) FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo')),
                (SELECT COUNT(*) FROM sys.columns WHERE object_id IN (SELECT object_id FROM sys.tables WHERE schema_id=SCHEMA_ID('dbo'))),
                (SELECT COUNT(*) FROM sys.key_constraints WHERE type='PK'),
                (SELECT COUNT(*) FROM sys.foreign_keys WHERE is_disabled=0 AND is_not_trusted=0),
                (SELECT TYPE_NAME(system_type_id) FROM sys.columns WHERE object_id=OBJECT_ID('dbo.Tbl_Clientes') AND name='DPI'),
                (SELECT COUNT(*) FROM dbo.Tbl_Usuarios WHERE Clave NOT LIKE 'PBKDF2-SHA256$%');", conexion))
            using (var lector = comando.ExecuteReader())
            {
                lector.Read();
                Afirmar(lector.GetInt32(0) == 16 && lector.GetInt32(1) == 130 && lector.GetInt32(2) == 16 && lector.GetInt32(3) == 18, "Esquema: 16 tablas, 130 campos, 16 PK, 18 FK confiables");
                Afirmar(lector.GetString(4) == "bigint", "DPI bigint");
                Afirmar(lector.GetInt32(5) == 0, "Sin contraseñas antiguas en texto plano");
            }
        }
    }

    static void ProbarDpi()
    {
        var negocio = new ClienteNegocio();
        string nombre = "prueba09_" + Guid.NewGuid().ToString("N").Substring(0, 12);
        negocio.Agregar(new Cliente { NombreCliente = nombre, Direccion = "Prueba temporal de integración", DPI = 1234567890123L, Edad = 25, Telefono = 55555555, Estado = true });
        Cliente cliente = negocio.Buscar(nombre, "Todos").Single();
        clienteCreado = cliente.CodigoCliente;
        Afirmar(cliente.DPI == 1234567890123L, "DPI de 13 dígitos guardado y leído");
        cliente.DPI = 9876543210123L;
        negocio.Editar(cliente);
        Afirmar(negocio.Buscar(nombre, "Todos").Single().DPI == cliente.DPI, "DPI de 13 dígitos actualizado");
        negocio.Eliminar(cliente.CodigoCliente);
        clienteCreado = 0;
        Afirmar(negocio.Buscar(nombre, "Todos").Count == 0, "Cliente temporal eliminado");
    }

    static void ProbarPermisos()
    {
        var negocio = new RolNegocio();
        RolAcceso original = negocio.Listar().Single(x => x.TipoUsuario == "Vendedor" && x.NombreModulo == "Clientes");
        using (var transaccion = new TransactionScope())
        {
            negocio.Eliminar(original.CodigoRolAcceso);
            negocio.Insertar(new RolAcceso { TipoUsuario = "Vendedor", NombreModulo = "Clientes", Estado = true });
            RolAcceso nuevo = negocio.Listar().Single(x => x.TipoUsuario == "Vendedor" && x.NombreModulo == "Clientes");
            Afirmar(negocio.ListarModulosPermitidos("Vendedor").Contains("Clientes"), "Crear permiso habilita el módulo");
            nuevo.Estado = false;
            negocio.Actualizar(nuevo);
            Afirmar(!negocio.ListarModulosPermitidos("Vendedor").Contains("Clientes"), "Desactivar permiso retira el módulo");
            negocio.Eliminar(nuevo.CodigoRolAcceso);
            Afirmar(!negocio.Listar().Any(x => x.CodigoRolAcceso == nuevo.CodigoRolAcceso), "Eliminar permiso");
            using (var conexion = ConexionDatos.CrearConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand("DELETE FROM dbo.Tbl_RolAccesos WHERE TipoUsuario='Vendedor';", conexion)) comando.ExecuteNonQuery();
            }
            Afirmar(negocio.ListarModulosPermitidos("Vendedor").SequenceEqual(new[] { "Inicio" }), "Sin permisos no se conceden accesos predeterminados");
            Usuario vendedor = usuarios.Listar().First(x => usuariosCreados.Contains(x.CodigoUsuario) && x.TipoUsuario == "Vendedor");
            usuarios.Autenticar(vendedor.NombreUsuario, clave);
            var resumen = new DashboardNegocio().ObtenerResumen();
            Afirmar(resumen.TotalClientes == 0 && resumen.TotalFacturas == 0 && resumen.TotalUsuarios == 0 && resumen.MontoTotalCotizado == 0,
                "Dashboard no expone datos de módulos sin permiso");
            Usuario administrador = usuarios.Listar().First(x => usuariosCreados.Contains(x.CodigoUsuario) && x.TipoUsuario == "Administrador");
            usuarios.Autenticar(administrador.NombreUsuario, clave);
            // Sin Complete: las operaciones se revierten y preservan la configuración original.
        }
        Afirmar(negocio.Listar().Any(x => x.CodigoRolAcceso == original.CodigoRolAcceso && x.Estado == original.Estado), "Permisos originales restaurados tras las pruebas");
    }

    static void ProbarRecordarUsuario()
    {
        string archivo = Path.Combine(Path.GetTempPath(), "publicidad09_" + Guid.NewGuid().ToString("N") + ".txt");
        Type preferencias = typeof(Login.Formularios.FrmLogin).Assembly.GetType("Login.Formularios.PreferenciasLogin");
        var guardar = preferencias.GetMethod("Guardar", BindingFlags.NonPublic | BindingFlags.Static);
        var leer = preferencias.GetMethod("Leer", BindingFlags.NonPublic | BindingFlags.Static);
        try
        {
            Afirmar((bool)guardar.Invoke(null, new object[] { true, "prueba09", "Vendedor", archivo }), "Recordar usuario guarda la preferencia");
            var datos = (string[])leer.Invoke(null, new object[] { archivo });
            Afirmar(datos.SequenceEqual(new[] { "prueba09", "Vendedor" }), "La preferencia conserva solo nombre y perfil");
            Afirmar((bool)guardar.Invoke(null, new object[] { false, "", "", archivo }) && !File.Exists(archivo), "Desmarcar Recordar usuario elimina la preferencia");
        }
        finally { if (File.Exists(archivo)) File.Delete(archivo); }
    }

    static void ProbarFormularios(string nombreAdmin)
    {
        Application.EnableVisualStyles();
        using (var login = new Login.Formularios.FrmLogin())
        {
            var tarjetas = (Array)typeof(Login.Formularios.FrmLogin).GetField("roles", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(login);
            Afirmar(tarjetas.Length == 5, "Login presenta cinco perfiles");
        }
        using (var principal = new FrmPrincipal(nombreAdmin, "Administrador"))
        {
            var crear = typeof(FrmPrincipal).GetMethod("Vista", BindingFlags.Instance | BindingFlags.NonPublic);
            var modulos = RolNegocio.Modulos.Concat(new[] { "Roles" });
            foreach (string nombre in modulos)
            {
                Form vista = (Form)crear.Invoke(principal, new object[] { nombre, "" });
                Afirmar(vista != null, "Formulario: " + nombre);
                if (nombre != "Inicio")
                {
                    Type puente = typeof(FrmPrincipal).Assembly.GetType("SistemaPublicidad.Formularios.ModuloCrud");
                    var lista = (System.Collections.IList)puente.GetMethod("Listar", BindingFlags.Public | BindingFlags.Static).Invoke(null, new object[] { nombre });
                    Afirmar(lista != null, "Lectura real del CRUD: " + nombre);
                }
            }
            FrmModulo clientes = (FrmModulo)crear.Invoke(principal, new object[] { "Clientes", "" });
            typeof(FrmPrincipal).GetField("vistaActiva", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(principal, clientes);
            principal.BuscarGlobal.Text = "prueba-busqueda";
            Afirmar(clientes.Buscar.Text == "prueba-busqueda", "Búsqueda global conectada al módulo");
            using (var inicio = new FrmInicio("Administrador"))
            {
                inicio.RefrescarResumen();
                int antes = usuarios.Listar().Count;
                Afirmar(inicio.StUsuarios.Valor == antes.ToString("N0"), "Dashboard refleja SQL Server");
                var temporal = usuarios.Listar().First(x => usuariosCreados.Contains(x.CodigoUsuario) && x.TipoUsuario != "Administrador");
                usuarios.Eliminar(temporal.CodigoUsuario);
                usuariosCreados.Remove(temporal.CodigoUsuario);
                inicio.RefrescarResumen();
                Afirmar(inicio.StUsuarios.Valor == (antes - 1).ToString("N0"), "Dashboard se actualiza tras un cambio");
            }
        }
    }

    static void Afirmar(bool condicion, string mensaje)
    {
        if (!condicion) throw new InvalidOperationException("FALLÓ: " + mensaje);
        comprobaciones++;
        Console.WriteLine("OK: " + mensaje);
    }
}

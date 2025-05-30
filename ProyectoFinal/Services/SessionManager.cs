using ProyectoFinal.Models;
namespace ProyectoFinal.Services
{
    public static class SessionManager
    {
        public static Usuario? UsuarioActual { get; private set; }

        public static void IniciarSesion(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public static void CerrarSesion()
        {
            UsuarioActual = null;
        }

        public static bool SesionActiva => UsuarioActual != null;
    }
}

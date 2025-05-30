using ProyectoFinal.Views;
namespace ProyectoFinal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent(); // Esto carga el XAML
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("RegistroPage", typeof(RegistroPage));
        }
    }
}


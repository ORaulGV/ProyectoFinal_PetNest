using ProyectoFinal.Views;

namespace ProyectoFinal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Uar el tema del sistema:
            //App.Current.UserAppTheme = AppTheme.Unspecified;

            // Por defecto inicie en modo claro:
            App.Current.UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Splash → Login → AppShell
            var splash = new NavigationPage(new Views.SplashPage());
            return new Window(splash);
        }
    }
}
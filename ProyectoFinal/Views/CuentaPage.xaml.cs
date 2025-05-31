using ProyectoFinal.Services;
using ProyectoFinal.ViewModels;
namespace ProyectoFinal.Views;

public partial class CuentaPage : ContentView
{
	public CuentaPage()
	{
		InitializeComponent();
        
    }

    private async void CerrarSesion_Clicked(object sender, EventArgs e)
    {
        bool confirm = await Shell.Current.DisplayAlert("Cerrar sesión", "¿Deseas salir de tu cuenta?", "Sí", "No");
        if (!confirm) return;

        SessionManager.CerrarSesion();

        // Reemplaza toda la MainPage para reiniciar la navegación correctamente
        Application.Current.MainPage = new AppShell(); // Asegúrate que AppShell esté bien configurado

        // Navega al login con ruta absoluta (asegúrate de tener la ruta registrada en AppShell.xaml)
        await Shell.Current.GoToAsync("//LoginPage");
    }


}
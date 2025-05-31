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
        bool confirm = await Shell.Current.DisplayAlert("Cerrar sesi�n", "�Deseas salir de tu cuenta?", "S�", "No");
        if (!confirm) return;

        SessionManager.CerrarSesion();

        // Reemplaza toda la MainPage para reiniciar la navegaci�n correctamente
        Application.Current.MainPage = new AppShell(); // Aseg�rate que AppShell est� bien configurado

        // Navega al login con ruta absoluta (aseg�rate de tener la ruta registrada en AppShell.xaml)
        await Shell.Current.GoToAsync("//LoginPage");
    }


}
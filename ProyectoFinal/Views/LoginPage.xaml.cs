using Microsoft.Maui.Controls;
namespace ProyectoFinal.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    
    // Navega a pantalla principal tras iniciar sesión
    private async void OnEntrarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPagePets");
    }

    // Navega a pantalla de registro (ajusta la ruta si cambias el nombre)
    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//RegistroPage");
    }

}
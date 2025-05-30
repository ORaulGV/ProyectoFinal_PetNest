using ProyectoFinal.Services;

namespace ProyectoFinal.Views;

public partial class CuentaPage : ContentView
{
	public CuentaPage()
	{
		InitializeComponent();
    }

    private async void CerrarSesion_Clicked(object sender, EventArgs e)
    {
        SessionManager.CerrarSesion();
        await Shell.Current.GoToAsync("//LoginPage");
    }


}
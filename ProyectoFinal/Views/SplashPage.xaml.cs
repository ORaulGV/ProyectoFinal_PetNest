using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace ProyectoFinal.Views;

public partial class SplashPage : ContentPage
{
	public SplashPage()
	{
		InitializeComponent();
		StartTimer();
	}

	private async void StartTimer()
	{
		await Task.Delay(3000); // Espera 2 segundos antes de navegar a la página principal
        Application.Current.MainPage = new AppShell();

        // Navega a la página de login (dentro del Shell)
        await Shell.Current.GoToAsync("//LoginPage");
    }
}
using ProyectoFinal.ViewModels;
using ProyectoFinal.Models;
namespace ProyectoFinal.Views;

public partial class MascotasPage : ContentView
{
    public MascotasPage()
    {
        InitializeComponent();

    }
    private async void OnAddPetClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AgregarPetPage");
    }


}



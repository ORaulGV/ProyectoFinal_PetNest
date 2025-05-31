using ProyectoFinal.ViewModels;
using ProyectoFinal.Models;
namespace ProyectoFinal.Views;

public partial class AlarmsPage : ContentView
{
    public AlarmsPage()
    {
        InitializeComponent();
    }

    private async void OnAddAlarmClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AgregarAlarmaPage");
    }


}
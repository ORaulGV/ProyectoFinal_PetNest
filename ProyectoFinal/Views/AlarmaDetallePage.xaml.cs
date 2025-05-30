using ProyectoFinal.ViewModels;
using ProyectoFinal.Models;
namespace ProyectoFinal.Views;

public partial class AlarmaDetallePage : ContentPage
{
    public AlarmaDetallePage(Alarms alarma)
    {
        InitializeComponent();
        BindingContext = new AlarmaDetalleViewModel(alarma);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is AlarmaDetalleViewModel vm)
        {
            vm.IsEditing = false;
            vm.IsViewing = true;
        }
    }
}
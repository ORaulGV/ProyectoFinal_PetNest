using ProyectoFinal.Models;
using ProyectoFinal.ViewModels;
using ProyectoFinal.Services;

namespace ProyectoFinal.Views;

[QueryProperty(nameof(IdAlarm), "IdAlarm")]
public partial class AlarmaDetallePage : ContentPage
{
    public AlarmaDetallePage()
    {
        InitializeComponent();
    }

    private int _idAlarm;
    public int IdAlarm
    {
        get => _idAlarm;
        set
        {
            _idAlarm = value;
            LoadAlarm(_idAlarm); // Aquí se carga la alarma desde el servicio
        }
    }

    private async void LoadAlarm(int id)
    {
        var alarma = await AlarmServices.GetAlarmByIdAsync(id);
        if (alarma != null)
        {
            BindingContext = new AlarmaDetalleViewModel(alarma);
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "No se encontró la alarma", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}

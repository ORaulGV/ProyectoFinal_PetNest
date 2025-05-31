using ProyectoFinal.ViewModels;
using ProyectoFinal.Models;
namespace ProyectoFinal.Views;


[QueryProperty(nameof(IdAlarm), "IdAlarm")]
public partial class AlarmaDetallePage : ContentPage
{
    public AlarmaDetallePage(Alarms alarma)
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
            LoadAlarm(_idAlarm);
        }
    }
    private async void LoadAlarm(int idAlarm)
    {
        var alarm = await ProyectoFinal.Services.AlarmServices.GetAlarmByIdAsync(idAlarm);
        BindingContext = new AlarmaDetalleViewModel(alarm);
    }
}

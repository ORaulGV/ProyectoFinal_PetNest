using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModels
{
    public partial class AgregarAlarmaViewModel : ObservableObject
    {
        [ObservableProperty]
        private Alarms alarma = new();

        [RelayCommand]
        public async Task GuardarAlarma()
        { 
            alarma.IdUser = SessionManager.UsuarioActual.IdUser;
            bool success = await AlarmServices.CreateAlarmAsync(alarma);
            if (success)
            {
                await Shell.Current.DisplayAlert("Éxito", "Alarma agregada correctamente.", "Aceptar");
                await Shell.Current.GoToAsync(".."); // Regresa a la página anterior
            }
            else 
            { 
                await Shell.Current.DisplayAlert("Error", "No se pudo agregar la alarma.", "Aceptar");
            }
        }
    }
}

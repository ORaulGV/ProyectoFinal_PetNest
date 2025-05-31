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
        private string alarmname;

        [ObservableProperty]
        private string hour;

        [ObservableProperty]
        private string frequency;

        [RelayCommand]
        public async Task GuardarAlarma()
        {
            System.Diagnostics.Debug.WriteLine($"UserId: {SessionManager.UsuarioActual.IdUser}, Title: {alarmname}, Hour: {hour}, Frecuency: {frequency}");

            if (string.IsNullOrWhiteSpace(Alarmname) || string.IsNullOrWhiteSpace(Hour) || string.IsNullOrWhiteSpace(Frequency))
            {
                await Shell.Current.DisplayAlert("Error", "Todos los campos son obligatorios.", "Aceptar");
                return;
            }

            var nuevaAlarma = new Alarms
            {
                IdUser = SessionManager.UsuarioActual.IdUser,
                AlarmName = Alarmname,
                Hour = Hour,
                Frequency = Frequency
            };

            bool success = await AlarmServices.CreateAlarmAsync(nuevaAlarma);

            if (success)
            {
                await Shell.Current.DisplayAlert("Éxito", "Alarma agregada correctamente.", "Aceptar");
                await Shell.Current.GoToAsync("//MainPagePets"); // Navega a MainPageAlarms
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo agregar la alarma.", "Aceptar");
            }
        }
    }
}

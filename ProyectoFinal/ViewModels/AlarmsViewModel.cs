using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using ProyectoFinal.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModels
{
    public partial class AlarmsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Alarms> alarma = new();

        [RelayCommand]
        public async Task CargarAlarmas()
        {
            if (!SessionManager.SesionActiva)
                return;
            int idUser = SessionManager.UsuarioActual.IdUser;
            var lista = await AlarmServices.GetAlarmsByUserIdAsync(idUser);

            if (lista != null)
            {
                Alarma = new ObservableCollection<Alarms>(lista);
            }
        }

        [RelayCommand]
        private async Task SeleccionarAlarma(Alarms alarma)
        {
            if (alarma != null)
            {
                await Shell.Current.GoToAsync(nameof(AlarmaDetallePage), new Dictionary<string, object>
                {
                    ["Alarma"] = alarma
                });
            }
        }

        public AlarmsViewModel()
        {
            CargarAlarmasCommand.Execute(null);
        }
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModels
{
    public partial class AlarmaDetalleViewModel : ObservableObject
    {
        [ObservableProperty]
        private Alarms alarma;
        [ObservableProperty]
        private bool isEditing = false;
        [ObservableProperty]
        private bool isViewing = true;

        public AlarmaDetalleViewModel(Alarms alarma)
        {
            Alarma = alarma;
        }

        [RelayCommand]
        private void EnableEditing()
        {
            IsEditing = true;
            IsViewing = false;
        }

        [RelayCommand]
        public async Task SaveChanges()
        {
            var result = await AlarmServices.UpdateAlarmAsync(Alarma);
            if (result)
            {
                IsEditing = false;
                IsViewing = true;
                await Shell.Current.DisplayAlert("Éxito", "Alarma actualizada correctamente.", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo actualizar la alarma.", "OK");
            }
        }

        [RelayCommand]
        public async Task Eliminar()
        { 
            bool confirm = await Shell.Current.DisplayAlert("Confirmar",
                "¿Estás seguro de que deseas eliminar esta alarma?", "Sí", "No");
            if (confirm)
            { 
                var result = await AlarmServices.DeleteAlarmAsync(Alarma.IdAlarm);
                if (result) { 
                    await Shell.Current.Navigation.PopAsync(); // Regresa a la lista de alarmas
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No se pudo eliminar la alarma.", "OK");
                }
            }
        }
    }
}

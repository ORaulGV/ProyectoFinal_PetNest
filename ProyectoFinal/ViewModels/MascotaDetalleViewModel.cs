using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModels
{
    public partial class MascotaDetalleViewModel : ObservableObject
    {
        [ObservableProperty]
        private Mascota mascota;

        [ObservableProperty]
        private bool isEditing = false;

        [ObservableProperty]
        private bool isViewing = true;

        public MascotaDetalleViewModel(Mascota mascota)
        {
            this.Mascota = mascota;
        }

        [RelayCommand]
        private void EnableEditing()
        {
            IsEditing = true;
            IsViewing = false;
        }

        [RelayCommand]
        private async Task SaveChanges()
        {
            var result = await PetServices.UpdatePetAsync(Mascota);
            if(result)
            {
                IsEditing = false;
                IsViewing = true;
                await Shell.Current.DisplayAlert("Éxito", "Mascota actualizada correctamente.", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo actualizar la mascota.", "OK");
            }
        }

        [RelayCommand]
        private async Task Eliminar()
        { 
            bool confirm = await Shell.Current.DisplayAlert("Confirmar",
                "¿Estás seguro de que deseas eliminar esta mascota?", "Sí", "No");
            if (confirm)
            { 
                var result = await PetServices.DeletePetAsync(Mascota.IdPet);
                if (result) 
                { 
                    await Shell.Current.Navigation.PopAsync(); // Regresa a la lista de mascotas
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No se pudo eliminar la mascota.", "OK");
                }
            }
        }

    }
}
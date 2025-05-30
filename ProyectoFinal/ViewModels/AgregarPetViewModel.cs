using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModels
{
    public partial class AgregarPetViewModel : ObservableObject
    {
        [ObservableProperty]
        private Mascota mascota = new();

        [RelayCommand]
        public async Task GuardarMascota()
        { 
            mascota.IdUser = SessionManager.UsuarioActual.IdUser;

            bool success = await PetServices.CreatePetAsync(mascota);

            if (success)
            {
                await Shell.Current.DisplayAlert("Éxito", "Mascota agregada correctamente.", "Aceptar");
                await Shell.Current.GoToAsync(".."); // Regresa a la página anterior
            }
            else 
            { 
                await Shell.Current.DisplayAlert("Error", "No se pudo agregar la mascota.", "Aceptar");
            }
        }
    }
}

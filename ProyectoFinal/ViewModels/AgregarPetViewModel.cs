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
        private string petname;

        [ObservableProperty]
        private string specie;

        [ObservableProperty]
        private string ageText;

        [RelayCommand]
        public async Task GuardarMascota()
        {
            System.Diagnostics.Debug.WriteLine($"UserId: {SessionManager.UsuarioActual.IdUser}, PetName: {petname}, Especie: {Specie}, Age: {AgeText}");

            if (string.IsNullOrWhiteSpace(Petname) || string.IsNullOrWhiteSpace(Specie) || string.IsNullOrWhiteSpace(AgeText))
            {
                await Shell.Current.DisplayAlert("Error", "Todos los campos son obligatorios.", "Aceptar");
                return;
            }

            if (!int.TryParse(AgeText, out int edadParseada))
            {
                await Shell.Current.DisplayAlert("Error", "Edad inválida", "Aceptar");
                return;
            }

            var nuevaMascota = new Mascota
            {
                IdUser = SessionManager.UsuarioActual.IdUser,
                PetName = Petname,
                Specie = Specie,
                Age = edadParseada
            };

            bool success = await PetServices.CreatePetAsync(nuevaMascota);

            if (success)
            {
                await Shell.Current.DisplayAlert("Éxito", "Mascota agregada correctamente.", "Aceptar");
                await Shell.Current.GoToAsync("//MainPagePets");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo agregar la mascota.", "Aceptar");
            }
        }
    }
}

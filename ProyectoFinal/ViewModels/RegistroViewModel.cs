using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModels
{
    public partial class RegistroViewModel : ObservableObject
    {
        [ObservableProperty]
        private Usuario usuario = new();

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string mail;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        private async Task Registrar()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Mail) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            var nuevoUsuario = new Usuario
            {
                Username = Username,
                Mail = Mail,
                Password = Password
            };

            bool exito = await UserServices.CreateUserAsync(nuevoUsuario);
            if (exito)
            {
                await Shell.Current.DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
                await Shell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No se pudo registrar el usuario", "OK");
            }
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        public async Task IniciarSesion()
        {
            Console.WriteLine($"Username: {Username}, Password: {Password}");
            var usuario = await UserServices.LoginAsync(Username, Password);

            if (usuario !=null)
            {
                SessionManager.IniciarSesion(usuario);
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }
    }
}

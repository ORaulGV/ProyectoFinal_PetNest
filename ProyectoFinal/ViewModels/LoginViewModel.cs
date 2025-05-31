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

            var usuario = await UserServices.LoginAsync(username, password);

            if (usuario !=null)
            {
                SessionManager.IniciarSesion(usuario);
                await Shell.Current.GoToAsync("//MainPagePets");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }
    }
}

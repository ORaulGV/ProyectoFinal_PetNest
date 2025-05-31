using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Usuario> usuarios = new();

        public Usuario UsuarioActual => SessionManager.UsuarioActual!;

        //Metodo para eliminar la cuenta de tu usuario
        [RelayCommand]
        public async Task EliminarUsuario()
        {
            bool confirm = await Shell.Current.DisplayAlert("Confirmar", "¿Deseas borrar tu cuenta?", "Sí", "No");
            if (confirm)
            {
                bool eliminado = await UserServices.DeleteUserAsync(UsuarioActual.IdUser);
                if (eliminado)
                {
                    SessionManager.CerrarSesion();
                    await Shell.Current.GoToAsync("//LoginPage");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No se pudo eliminar la cuenta", "OK");
                }
            }
        }
    }
}

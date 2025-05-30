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


        //Metodo para eliminar la cuenta de tu usuario
        [RelayCommand]
        public async Task EliminarUsuario(Usuario usuario)
        {
            bool confirm = await Shell.Current.DisplayAlert("Confirmar", "¿Deseas borrar tu cuenta?", "Sí", "No");
            if (confirm)
            {
                bool eliminado = await UserServices.DeleteUserAsync(usuario.IdUser);
                if (eliminado)
                {
                    Usuarios.Remove(usuario);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No se pudo eliminar", "OK");
                }
            }
        }
    }
}

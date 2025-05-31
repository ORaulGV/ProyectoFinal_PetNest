using CommunityToolkit.Mvvm.ComponentModel;
using ProyectoFinal.Models;
using ProyectoFinal.Services;

namespace ProyectoFinal.ViewModels
{
    public partial class MainPagePetsViewModel : ObservableObject
    {
        [ObservableProperty]
        private Usuario usuarioActual;

        public MainPagePetsViewModel()
        {
            UsuarioActual = SessionManager.UsuarioActual;
        }
    }
}

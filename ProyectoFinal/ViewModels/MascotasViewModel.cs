using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModels
{
    public partial class MascotasViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Mascota> mascotas = new();

        [RelayCommand]
        public async Task CargarMascotas()
        {
            if (!SessionManager.SesionActiva)
                return;

            int idUser = SessionManager.UsuarioActual.IdUser;
            var lista = await PetServices.GetPetsIdUserAsync(idUser);

            if (lista != null)
            {
                Mascotas = new ObservableCollection<Mascota>(lista);
            }
        }

        public MascotasViewModel()
        {
            CargarMascotasCommand.Execute(null);
        }
    }
}

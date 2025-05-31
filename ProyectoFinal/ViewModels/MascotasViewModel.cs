using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using ProyectoFinal.Views;
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
            {
                return;
            }
            int idUser = SessionManager.UsuarioActual.IdUser;
            var lista = await PetServices.GetPetsIdUserAsync(idUser);            

            if (lista != null)
            {
                Mascotas = new ObservableCollection<Mascota>(lista);
            }
        }
        [RelayCommand]
        private async Task SeleccionarMascota(Mascota mascota)
        {
            if (mascota == null) return;

            await Shell.Current.GoToAsync($"{nameof(MascotaDetallePage)}?IdPet={mascota.IdPet}");
        }

        public MascotasViewModel()
        {
            CargarMascotasCommand.Execute(null);
        }
    }
}

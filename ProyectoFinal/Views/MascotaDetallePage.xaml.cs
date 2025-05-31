using ProyectoFinal.ViewModels;
using ProyectoFinal.Models;

namespace ProyectoFinal.Views;

[QueryProperty(nameof(IdPet), "IdPet")]
public partial class MascotaDetallePage : ContentPage
{
    public MascotaDetallePage()
    {
        InitializeComponent();
    }

    private int _idPet;
    public int IdPet
    {
        get => _idPet;
        set
        {
            _idPet = value;
            LoadMascota(_idPet);
        }
    }

    private async void LoadMascota(int idPet)
    {
        var mascota = await ProyectoFinal.Services.PetServices.GetPetByIdAsync(idPet);
        BindingContext = new MascotaDetalleViewModel(mascota);
    }
}
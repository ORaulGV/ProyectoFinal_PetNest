using ProyectoFinal.ViewModels;
using ProyectoFinal.Models;

namespace ProyectoFinal.Views;

public partial class MascotaDetallePage : ContentPage
{
	public MascotaDetallePage(Mascota mascota)
	{
		InitializeComponent();
        BindingContext = new MascotaDetalleViewModel(mascota);
    }

}
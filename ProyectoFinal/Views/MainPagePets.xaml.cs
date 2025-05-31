namespace ProyectoFinal.Views;
using ProyectoFinal.ViewModels;
public partial class MainPagePets : ContentPage
{

    private MascotasViewModel mascotasVM = new();
    public MainPagePets()
    {
        InitializeComponent();
        BindingContext = new MainPagePetsViewModel();
        ShowPetsPage(null, null);
        PetsView.BindingContext = new MascotasViewModel();
        AlarmsView.BindingContext = new AlarmsViewModel();
        
    }

    private void ShowPetsPage(object sender, EventArgs e)
    {
        PetsView.IsVisible = true;
        AlarmsView.IsVisible = false;
        CuentaView.IsVisible = false;
    }

    private void ShowAlarmsPage(object sender, EventArgs e)
    {
        PetsView.IsVisible = false;
        AlarmsView.IsVisible = true;
        CuentaView.IsVisible = false;
    }

    private void ShowCuentaPage(object sender, EventArgs e)
    {
        PetsView.IsVisible = false;
        AlarmsView.IsVisible = false;
        CuentaView.IsVisible = true;
    }
}

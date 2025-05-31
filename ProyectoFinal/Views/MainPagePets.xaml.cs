namespace ProyectoFinal.Views;
using ProyectoFinal.ViewModels;
public partial class MainPagePets : ContentPage
{

    private MascotasViewModel mascotasVM = new();
    private AlarmsViewModel alarmsVM = new();
    public MainPagePets()
    {
        InitializeComponent();
        BindingContext = new MainPagePetsViewModel();
        ShowPetsPage(null, null);
        PetsView.BindingContext = new MascotasViewModel();   
        AlarmsView.BindingContext = new AlarmsViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is MascotasViewModel vm)
        {
            vm.CargarMascotasCommand.Execute(null);
        }
        if (AlarmsView.BindingContext is AlarmsViewModel avm)
        {
            avm.CargarAlarmasCommand.Execute(null);
        }
    }

    private void ShowPetsPage(object sender, EventArgs e)
    {
        PetsView.IsVisible = true;
        AlarmsView.IsVisible = false;
        CuentaView.IsVisible = false;
        if (PetsView.BindingContext is MascotasViewModel vm)
        {
            vm.CargarMascotasCommand.Execute(null);
        }
    }

    private void ShowAlarmsPage(object sender, EventArgs e)
    {
        PetsView.IsVisible = false;
        AlarmsView.IsVisible = true;
        CuentaView.IsVisible = false;
        if (AlarmsView.BindingContext is AlarmsViewModel avm)
        {
            avm.CargarAlarmasCommand.Execute(null);
        }
    }

    private void ShowCuentaPage(object sender, EventArgs e)
    {
        PetsView.IsVisible = false;
        AlarmsView.IsVisible = false;
        CuentaView.IsVisible = true;
    }
}

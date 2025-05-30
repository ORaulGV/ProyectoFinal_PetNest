using ProyectoFinal.ViewModels;

namespace ProyectoFinal.Views
{
    public partial class AgregarAlarmaPage : ContentPage
    {
        public AgregarAlarmaPage()
        {
            InitializeComponent();
            BindingContext = new AgregarAlarmaViewModel();
        }

        private async void OnRegresarClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

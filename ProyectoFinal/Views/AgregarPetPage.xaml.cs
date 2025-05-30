namespace ProyectoFinal.Views;

public partial class AgregarPetPage : ContentPage
{
	public AgregarPetPage()
	{
		InitializeComponent();
	}
    private async void OnRegresarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

}
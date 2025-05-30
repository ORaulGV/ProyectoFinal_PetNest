namespace ProyectoFinal.Views;

public partial class AjustesPage : ContentPage
{
    public AjustesPage()
    {
        InitializeComponent();
        DarkModeSwitch.IsToggled = Application.Current.UserAppTheme == AppTheme.Dark;
    }

    private void OnDarkModeToggled(object sender, ToggledEventArgs e)
    {
        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }
}

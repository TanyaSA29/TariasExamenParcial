namespace TariasExamen.Views;

public partial class AcercaDe : ContentPage
{
    public AcercaDe(string usuarioConectado)
    {
        InitializeComponent();
        // Mostrar el usuario que inició sesión
        LblUsuario.Text = $"Usuario conectado: {usuarioConectado}";
    }

    private async void BtnCerrar_Clicked(object sender, EventArgs e)
    {
        // Cierra la ventana y regresa a la anterior (Login)
        await Navigation.PopAsync();
    }
}
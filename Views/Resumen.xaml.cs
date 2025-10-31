namespace TariasExamen.Views;

public partial class Resumen : ContentPage
{
    public Resumen(string usuarioConectado, string nombre, string apellido, string va,
                   DateTime fecha, string ciudad, decimal montoInicial,
                   decimal cuotaMensual, decimal pagoTotal)
    {
        InitializeComponent();

        // Usuario conectado
        LblUsuario.Text = $"Usuario conectado: {usuarioConectado}";

        // Datos del estudiante
        LblNombre.Text = nombre;
        LblApellido.Text = apellido;
        LblVA.Text = va;
        LblFecha.Text = fecha.ToString("dd/MM/yyyy");
        LblCiudad.Text = ciudad;
        LblMonto.Text = montoInicial.ToString("0.00");
        LblCuota.Text = cuotaMensual.ToString("0.00");
        LblTotal.Text = pagoTotal.ToString("0.00");
    }

    private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
    {
        // Volver al Login
        await Navigation.PopToRootAsync();
    }
}

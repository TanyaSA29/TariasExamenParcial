namespace TariasExamen.Views;

public partial class Registrate : ContentPage
{
    private string usuarioConectado;
    private decimal costoUPS = 300m;

    public Registrate(string usuario)
    {
        InitializeComponent();
        usuarioConectado = usuario;
        LblUsuario.Text = $"Usuario conectado: {usuarioConectado}";
    }

    private void SoloNumeros(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (!string.IsNullOrEmpty(entry.Text) && !entry.Text.All(char.IsDigit))
        {
            entry.Text = new string(entry.Text.Where(char.IsDigit).ToArray());
        }
    }

    private void SoloLetras(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (!string.IsNullOrEmpty(entry.Text) && !entry.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
        {
            entry.Text = new string(entry.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
        }
    }

    // Botón para calcular cuota mensual
    private void BtnCalcularCuota_Clicked(object sender, EventArgs e)
    {
        if (decimal.TryParse(EntryMonto.Text, out decimal montoInicial))
        {
            decimal resto = costoUPS - montoInicial;
            decimal cuota = (resto / 3) + (costoUPS * 0.05m); // +5% del costo
            EntryCuota.Text = cuota.ToString("0.00");
        }
        else
        {
            DisplayAlert("Error", "Ingrese un monto válido", "Aceptar");
        }
    }

    private async void BtnVerResumen_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(EntryNombre.Text) || string.IsNullOrEmpty(EntryApellido.Text) ||
            PickerVA.SelectedItem == null || PickerCiudad.SelectedItem == null || string.IsNullOrEmpty(EntryMonto.Text) || string.IsNullOrEmpty(EntryCuota.Text))
        {
            await DisplayAlert("Error", "Complete todos los campos y calcule la cuota", "Aceptar");
            return;
        }

        decimal montoInicial = decimal.Parse(EntryMonto.Text);
        decimal cuota = decimal.Parse(EntryCuota.Text);
        decimal pagoTotal = montoInicial + (cuota * 3);

        DateTime fechaSeleccionada = DatePickerFecha.Date;

        await Navigation.PushAsync(new Resumen(
            usuarioConectado,
            EntryNombre.Text,
            EntryApellido.Text,
            PickerVA.SelectedItem.ToString(),
            fechaSeleccionada,
            PickerCiudad.SelectedItem.ToString(),
            montoInicial,
            cuota,
            pagoTotal
        ));
    }
}
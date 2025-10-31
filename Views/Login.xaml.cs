using Microsoft.Win32;

namespace TariasExamen.Views;

public partial class Login : ContentPage
{
    // Matriz de usuarios y contraseñas (3 filas, 2 columnas)
    string[,] usuarios = new string[3, 2]
    {
        { "estudiante2025", "moviles" },
        { "uisrael", "2025" },
        { "sistemas", "2025_1" }
    };

    public Login()
    {
        InitializeComponent();
    }

    // Botón Iniciar sesión
    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        string usuario = EntryUsuario.Text;
        string password = EntryPassword.Text;
        bool acceso = false;

        for (int i = 0; i < usuarios.GetLength(0); i++)
        {
            if (usuarios[i, 0] == usuario && usuarios[i, 1] == password)
            {
                acceso = true;
                break;
            }
        }

        if (acceso)
        {
            // Abrir ventana Registro y enviar usuario conectado
            await Navigation.PushAsync(new Registrate(usuario));
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos", "Aceptar");
        }
    }
 

    // Botón Acerca de
    private async void BtnAcercaDe_Clicked(object sender, EventArgs e)
    {
        string usuario = EntryUsuario.Text;
        await Navigation.PushAsync(new AcercaDe(usuario));
    }
}
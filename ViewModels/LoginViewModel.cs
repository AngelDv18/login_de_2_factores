using System.ComponentModel;
using System.Windows.Input;
using login2fa.Models;
using login2fa.Services;
using Microsoft.Maui.Controls;
using BCrypt.Net;

namespace login2fa.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string usuario;
        private string contrasena;

        public string Usuario
        {
            get => usuario;
            set
            {
                usuario = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Usuario)));
            }
        }

        public string Contrasena
        {
            get => contrasena;
            set
            {
                contrasena = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Contrasena)));
            }
        }

        public ICommand LoginCommand { get; }

        public static Usuario UsuarioAutenticado;
        public static string CodigoActual;

        public LoginViewModel()
        {
            Usuario = string.Empty;
            Contrasena = string.Empty;

            LoginCommand = new Command(async () => await IniciarSesionAsync());
        }

        private async Task IniciarSesionAsync()
        {
            var servicio = new MySqlService();
            var usuario = await servicio.ObtenerUsuarioPorNombreOCorreoAsync(Usuario);

            if (usuario != null && BCrypt.Net.BCrypt.Verify(Contrasena, usuario.Contrasena))
            {
                try
                {
                    UsuarioAutenticado = usuario;

                    // Generar código PIN
                    var rnd = new Random();
                    CodigoActual = rnd.Next(100000, 999999).ToString();

                    var emailService = new EmailService();
                    await emailService.EnviarPinPorCorreo(usuario.Email, CodigoActual);

                    await Application.Current.MainPage.DisplayAlert("PIN enviado",
                        $"Se ha enviado un código de verificación al correo: {usuario.Email}",
                        "OK");

                    await Shell.Current.GoToAsync("///verificar");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error al enviar el correo",
                        $"No se pudo enviar el código de verificación: {ex.Message}", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Credenciales inválidas", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

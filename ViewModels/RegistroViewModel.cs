using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using login2fa.Models;
using login2fa.Services;
using Microsoft.Maui.Controls;

namespace login2fa.ViewModels
{
    public class RegistroViewModel : INotifyPropertyChanged
    {
        public Usuario Usuario { get; set; } = new();
        public ICommand RegistrarCommand { get; }

        public RegistroViewModel()
        {
            RegistrarCommand = new Command(async () => await RegistrarUsuarioAsync());
        }

        private async Task RegistrarUsuarioAsync()
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(Usuario.UsuarioNombre) ||
                string.IsNullOrWhiteSpace(Usuario.Nombre) ||
                string.IsNullOrWhiteSpace(Usuario.Apellido) ||
                string.IsNullOrWhiteSpace(Usuario.Telefono) ||
                string.IsNullOrWhiteSpace(Usuario.Email) ||
                string.IsNullOrWhiteSpace(Usuario.Contrasena))
            {
                await Application.Current.MainPage.DisplayAlert("Validación", "Todos los campos son obligatorios", "OK");
                return;
            }

            var servicio = new MySqlService();

            // Aplicar hash a la contraseña antes de guardar
            Usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(Usuario.Contrasena);

            bool resultado = await servicio.RegistrarUsuarioAsync(Usuario);

            if (resultado)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado", "OK");
                await Shell.Current.GoToAsync("///login");// Volver al login
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Registro fallido", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

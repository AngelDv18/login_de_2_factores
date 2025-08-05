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
using System.Security.Cryptography; // Asegúrate de tener esta referencia para usar BCrypt
using BCrypt.Net; // Asegúrate de tener la referencia a la librería BCrypt.Net-Next

namespace login2fa.ViewModels
{
    public class VerificacionPinViewModel : INotifyPropertyChanged
    {
        public string PinIngresado { get; set; }
        public ICommand ConfirmarCommand { get; }
        public ICommand ReenviarCommand { get; }

        public VerificacionPinViewModel()
        {
            ConfirmarCommand = new Command(ConfirmarPin);
            ReenviarCommand = new Command(async () => await ReenviarPin());
        }

        private async void ConfirmarPin()
        {
            if (PinIngresado == LoginViewModel.CodigoActual)
            {
                await Application.Current.MainPage.DisplayAlert("Correcto", "PIN verificado", "OK");
                await Shell.Current.GoToAsync("///perfil");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Código incorrecto", "OK");
            }
        }

        private async Task ReenviarPin()
        {
            Random rnd = new();
            LoginViewModel.CodigoActual = rnd.Next(100000, 999999).ToString();

            var emailService = new EmailService();
            await emailService.EnviarPinPorCorreo(LoginViewModel.UsuarioAutenticado.Email, LoginViewModel.CodigoActual);

            await Application.Current.MainPage.DisplayAlert("Reenviado", "Nuevo código enviado", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

	using login2fa.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using login2fa.Models;
using login2fa.Services;
using System.Windows.Input;
using MySql.Data.MySqlClient;


namespace login2fa.Views;

public partial class PerfilPage : ContentPage
{
	public PerfilPage()
	{
		InitializeComponent();
        BindingContext = new PerfilViewModel();
    }
    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        bool confirmacion = await Application.Current.MainPage.DisplayAlert(
            "Cerrar sesión",
            "¿Estás seguro de que deseas cerrar sesión?",
            "Sí", "No");

        if (confirmacion)
        {
            // Limpiar sesión
            LoginViewModel.UsuarioAutenticado = null;
            LoginViewModel.CodigoActual = null;

            // Navegar al login
            await Shell.Current.GoToAsync("///login");
            // 🔁 Forzar reinicio del BindingContext
            if (Shell.Current.CurrentPage is ContentPage loginPage)
            {
                loginPage.BindingContext = new LoginViewModel();
            }
        }
    }
}
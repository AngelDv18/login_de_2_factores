using System;
using Microsoft.Maui.Controls;
using login2fa.ViewModels; // Asegúrate de que el namespace sea correcto
using login2fa.Models; // Asegúrate de que el namespace sea correcto
using login2fa.Services; // Asegúrate de que el namespace sea correcto


namespace login2fa.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel(); // ESTA LÍNEA ES CLAVE
    }
    // LoginPage.xaml.cs
    private async void OnRegistroClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///registro");
    }

}
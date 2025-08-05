using System;
using Microsoft.Maui.Controls;
using login2fa.ViewModels; // Asegúrate de que el namespace sea correcto
using login2fa.Models; // Asegúrate de que el namespace sea correcto
using login2fa.Services; // Asegúrate de que el namespace sea correcto


namespace login2fa.Views;

public partial class RegistroPage : ContentPage
{
	public RegistroPage()
	{
		InitializeComponent();
        BindingContext = new RegistroViewModel(); // 🔴 AQUI se enlaza correctamente
    }
    private async void OnVolverLoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///login");
    }
}
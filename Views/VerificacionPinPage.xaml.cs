using System;
using Microsoft.Maui.Controls;
using login2fa.ViewModels; // Asegúrate de que el namespace sea correcto
using login2fa.Models; // Asegúrate de que el namespace sea correcto
using login2fa.Services; // Asegúrate de que el namespace sea correcto


namespace login2fa.Views;

public partial class VerificacionPinPage : ContentPage
{
	public VerificacionPinPage()
	{
		InitializeComponent();
        BindingContext = new VerificacionPinViewModel();
        BindingContext = new login2fa.ViewModels.VerificacionPinViewModel();
    }
}
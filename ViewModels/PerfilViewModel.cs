using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using login2fa.Models;
using login2fa.Services;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Windows.Input;


namespace login2fa.ViewModels
{
    public class PerfilViewModel
    {
        public string NombreCompleto => $"{LoginViewModel.UsuarioAutenticado.Nombre} {LoginViewModel.UsuarioAutenticado.Apellido}";
        public string Telefono => LoginViewModel.UsuarioAutenticado.Telefono;
        public string Email => LoginViewModel.UsuarioAutenticado.Email;
    }

}

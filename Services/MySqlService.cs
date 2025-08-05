using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login2fa.Models;
using MySqlConnector;

namespace login2fa.Services
{
    public class MySqlService
    {
        private const string connectionString = "server=10.0.2.2;user=root;password=;database=login2fa";

        public async Task<bool> RegistrarUsuarioAsync(Usuario usuario)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var cmd = new MySqlCommand("INSERT INTO usuarios (usuario, nombre, apellido, telefono, email, contrasena) " +
                                       "VALUES (@usuario, @nombre, @apellido, @telefono, @correo, @contrasena)", connection);

            cmd.Parameters.AddWithValue("@usuario", usuario.UsuarioNombre);
            cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
            cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
            cmd.Parameters.AddWithValue("@correo", usuario.Email);
            cmd.Parameters.AddWithValue("@contrasena", usuario.Contrasena);

            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<Usuario?> ObtenerUsuarioPorNombreOCorreoAsync(string input)
        {
            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            var cmd = new MySqlCommand(
                "SELECT * FROM usuarios WHERE usuario = @input OR email = @input", connection); // ✅ Sin comillas en SQL

            cmd.Parameters.AddWithValue("@input", input); // ✅ Se inyecta correctamente como parámetro

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Usuario
                {
                    Id = reader.GetInt32("id"),
                    UsuarioNombre = reader.GetString("usuario"),
                    Nombre = reader.GetString("nombre"),
                    Apellido = reader.GetString("apellido"),
                    Telefono = reader.GetString("telefono"),
                    Email = reader.GetString("email"),
                    Contrasena = reader.GetString("contrasena")
                };
            }

            return null;
        }

    }
}

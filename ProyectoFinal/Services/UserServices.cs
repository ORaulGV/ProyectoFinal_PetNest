using System.Net.Http.Json;
using ProyectoFinal.Models;

namespace ProyectoFinal.Services
{
    public static class UserServices
    {
        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://petappproyetodam.azurewebsites.net/")
        };

        //Lamada a la APi de Usuarios para el Inicio de Sesión
        public static async Task<Usuario?> LoginAsync(string username, string password)
        {
            var payload = new
            {
                idUser = 0,
                Username = username,
                mail ="",
                Password = password
            };
            var response = await _httpClient.PostAsJsonAsync("api/User/login", payload);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }
            return null;
        }


        //Lamada a la APi de Usuarios para el Registro/Create

        public static async Task<bool> CreateUserAsync(Usuario nuevousUario)
        {
            var response = await _httpClient.PostAsJsonAsync("api/User/create",nuevousUario);
            return response.IsSuccessStatusCode;
        }

        //Lamada a la APi de Usuarios para eliminar un usuario
        public static async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/User/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar user: {ex.Message}");
                return false;
            }
        }
    }
}

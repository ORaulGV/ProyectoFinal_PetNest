using System.Net.Http.Json;
using ProyectoFinal.Models;

namespace ProyectoFinal.Services
{
    public static class PetServices
    {
        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://petappproyetodam.azurewebsites.net/")
        };

        //Lamada a la APi de Mascotas para CREAR mascotas

        public static async Task<bool> CreatePetAsync(Mascota nuevaMascota)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Pet/create", nuevaMascota);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"Error al crear mascota: {response.StatusCode} - {errorContent}");
            }
            return response.IsSuccessStatusCode;
        }

        //Lamada a la APi de Mascotas para Actualizar mascotas
        public static async Task<bool> UpdatePetAsync(Mascota mascota)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Pet/update", mascota);
            return response.IsSuccessStatusCode;
        }

        //Lamada a la APi de Mascotas para eliminar mascotas
        public static async Task<bool> DeletePetAsync(int id) 
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Pet/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {   
                Console.WriteLine($"Error al eliminar mascota: {ex.Message}");
                return false;
            }
        }

        //Llamada a la API para obtener los datos de una mascota por su ID
        public static async Task<Mascota?> GetPetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Mascota>($"api/Pet/{id}");
        }


        //Llamada a la API de Mascotas para obtener todas las mascotas de un usuario
        public static async Task<List<Mascota>?> GetPetsIdUserAsync(int idUser)
        { 
            var response = await _httpClient.GetFromJsonAsync<List<Mascota>>($"api/Pet/user/{idUser}");
            return response ?? new List<Mascota>();

            //No crear un error si no hay mascotas, retornar una lista vacía
            //Ya que al crear una cuenta de usuario, no se tiene mascotas creadas aún
        }
    }
}

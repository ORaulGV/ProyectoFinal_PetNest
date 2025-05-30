using System.Net.Http.Json;
using ProyectoFinal.Models;

namespace ProyectoFinal.Services
{
    public static class AlarmServices
    {
        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://petappproyetodam.azurewebsites.net/")
        };

        //Llamada a la Api para Crear Nueva Alarma
        public static async Task<bool> CreateAlarmAsync(Alarms nuevaAlarma)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Alarm/create", nuevaAlarma);
            return response.IsSuccessStatusCode;
        }

        //Llamada a la Api para Actualizar Alarma
        public static async Task<bool> UpdateAlarmAsync(Alarms alarma)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Alarm/update", alarma);
            return response.IsSuccessStatusCode;
        }

        //Llamada a la Api para Eliminar Alarma
        public static async Task<bool> DeleteAlarmAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Alarm/{id}");
            return response.IsSuccessStatusCode;
        }

        //Llamada a la Api para Obtener la Alarma por ID
        public static async Task<Alarms?> GetAlarmByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Alarms>($"api/Alarm/{id}");
        }

        //Llamada a la Api para Obtener todas las Alarmas de un Usuario
        public static async Task<List<Alarms>?> GetAlarmsByUserIdAsync(int idUser)
        {
            var response = await _httpClient.GetFromJsonAsync<List<Alarms>>($"api/Alarm/user/{idUser}");
            return response ?? new List<Alarms>();
            // No crear un error si no hay alarmas, retornar una lista vacía
            // Ya que al crear una cuenta de usuario, no se tiene alarmas creadas aún
        }
    }
}

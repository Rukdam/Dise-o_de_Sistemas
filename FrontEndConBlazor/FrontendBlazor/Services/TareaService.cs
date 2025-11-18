using FrontendBlazor.Models;
using System.Net.Http.Json;

namespace FrontendBlazor.Services
{
    public class TareaService
    {
        private readonly HttpClient _httpClient;

        public TareaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Tarea>> GetTareasAsync()
        {
            try
            {
                var tareas = await _httpClient.GetFromJsonAsync<List<Tarea>>("api/tareas");
                return tareas ?? new List<Tarea>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tareas: {ex.Message}");
                return new List<Tarea>();
            }
        }

        public async Task<Tarea?> GetTareaAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Tarea>($"api/tareas/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tarea: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Tarea>> GetTareasPorProyectoAsync(int proyectoId)
        {
            try
            {
                var tareas = await _httpClient.GetFromJsonAsync<List<Tarea>>($"api/tareas/proyecto/{proyectoId}");
                return tareas ?? new List<Tarea>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener tareas del proyecto: {ex.Message}");
                return new List<Tarea>();
            }
        }

        public async Task<bool> CreateTareaAsync(Tarea tarea)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/tareas", tarea);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear tarea: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateTareaAsync(int id, Tarea tarea)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/tareas/{id}", tarea);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar tarea: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteTareaAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/tareas/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar tarea: {ex.Message}");
                return false;
            }
        }
    }
}

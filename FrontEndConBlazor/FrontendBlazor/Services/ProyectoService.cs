using FrontendBlazor.Models;
using System.Net.Http.Json;

namespace FrontendBlazor.Services
{
    public class ProyectoService
    {
        private readonly HttpClient _httpClient;

        public ProyectoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Proyecto>> GetProyectosAsync()
        {
            try
            {
                var proyectos = await _httpClient.GetFromJsonAsync<List<Proyecto>>("api/proyectos");
                return proyectos ?? new List<Proyecto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener proyectos: {ex.Message}");
                return new List<Proyecto>();
            }
        }

        public async Task<Proyecto?> GetProyectoAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Proyecto>($"api/proyectos/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener proyecto: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateProyectoAsync(Proyecto proyecto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/proyectos", proyecto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear proyecto: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateProyectoAsync(int id, Proyecto proyecto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/proyectos/{id}", proyecto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar proyecto: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteProyectoAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/proyectos/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar proyecto: {ex.Message}");
                return false;
            }
        }
    }
}

using FrontendBlazor.Models;
using System.Net.Http.Json;

namespace FrontendBlazor.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            try
            {
                var usuarios = await _httpClient.GetFromJsonAsync<List<Usuario>>("api/usuarios");
                return usuarios ?? new List<Usuario>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
                return new List<Usuario>();
            }
        }

        public async Task<Usuario?> GetUsuarioAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Usuario>($"api/usuarios/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuario: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateUsuarioAsync(Usuario usuario)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/usuarios", usuario);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateUsuarioAsync(int id, Usuario usuario)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/usuarios/{id}", usuario);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar usuario: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/usuarios/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex.Message}");
                return false;
            }
        }
    }
}

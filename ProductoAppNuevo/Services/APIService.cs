using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProductoApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace ProductoApp.Services
{
    public class APIService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;

        public APIService()
        {

            _baseUrl = "https://apiproductos20231211110203.azurewebsites.net/";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }


        public async Task<Plato> obtenerPlato(int IdPlato)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync($"api/Plato/{IdPlato}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Plato>(content);
                return producto;
            }
            return null;

        }


        public async Task<List<Plato>> obtenerPlato()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync("api/Plato");
            var json_response = await response.Content.ReadAsStringAsync();
            List<Plato> productos = JsonConvert.DeserializeObject<List<Plato>>(json_response);
            return productos;
        }

        public async Task<bool> añadirPlato(Plato plato)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var jsonString = JsonConvert.SerializeObject(plato);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/Plato", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> actualizarPlato(int IdPlato, Plato plato)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var jsonString = JsonConvert.SerializeObject(plato);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/Plato/{IdPlato}", content);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> eliminarPlato(int IdPlato)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.DeleteAsync($"api/Plato/{IdPlato}");
            return response.IsSuccessStatusCode;
        }

        public Usuario PostUsuario(Usuario usuario)
        {
            if (usuario != null){
                if (usuario.Username.Equals("David") && usuario.Password.Equals("1234"))
                {
                    return new Usuario
                    {
                        IdUsuario=100,
                        Username=usuario.Username,
                        Password="",
                    };
                }
            
            }

            return null;
        }

        public async Task<bool> ActualizarCantidadEnBaseDeDatos(int id, int nuevaCantidad)
        {
            try
            {
                var plato = new Plato { IdPlato = id, Cantidad = nuevaCantidad };
                var jsonString = JsonConvert.SerializeObject(plato);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"api/Plato/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Actualización exitosa - IdPlato: {id}, Nueva Cantidad: {nuevaCantidad}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error al actualizar el plato. Respuesta HTTP: {response.StatusCode}");

                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error Content: {errorContent}");

                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de red: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> ActualizarPlato(int idPlato, Plato plato)
        {
            var jsonString = JsonConvert.SerializeObject(plato);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/Plato/{idPlato}", content);

            return response.IsSuccessStatusCode;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

}
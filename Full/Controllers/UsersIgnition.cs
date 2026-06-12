using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FULL.Models;
using System.ComponentModel.Design;
using System.Text.Json.Nodes;

namespace Inspinia.Controllers
{
    public class UsersIgnitionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsersIgnitionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetIgnitionCards(string user_source = null)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                // Consumir el endpoint de tu contenedor Docker de Ignition
                //  BIEN: Sin el '?' intruso y con el '$' para inyectar el parámetro dinámico
                var apiResponse = await client.GetFromJsonAsync<IgnitionApiResponse>($"http://localhost:8088/system/webdev/API/API?user_source={user_source}");


                if (apiResponse?.Usuarios == null || apiResponse.Usuarios.Count == 0)
                {
                    return Content("<div class='alert alert-warning m-3'>No se encontraron registros de usuarios en el Gateway.</div>");
                }

                // ⭐ AQUÍ ESTÁ LO QUE REQUERÍAS: Asignar los campos globales de la API
                ViewData["UserSource"] = apiResponse.UserSource;
                ViewData["Description"] = apiResponse.Description;

                // Renderiza la vista parcial enviándole la lista completa de usuarios
                return PartialView("~/Views/Shared/Partials/_UserCard.cshtml", apiResponse.Usuarios);
            }
            catch (System.Exception ex)
            {
                return Content($"<div class='alert alert-danger m-3'><strong>Error de comunicación con Ignition:</strong> {ex.Message}</div>");
            }
        }

        public IActionResult Users()
        {
            return PartialView();
        }
        

        [HttpGet]
        public async Task<IActionResult> GetUserSourcesDropdown()
        {
            try
            {
                using (var directoClient = new System.Net.Http.HttpClient())
                {
                    var apiResponseAPIUserList = await directoClient.GetFromJsonAsync<List<object>>("http://localhost:8088/system/webdev/API/APIUserList");
                    if (apiResponseAPIUserList == null || apiResponseAPIUserList.Count == 0)
                    {
                        return NotFound("No se encontraron fuentes de usuario.");
                    }
                    return Json(apiResponseAPIUserList);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Error de comunicación con Ignition: {ex.Message}");
            }
        }


    }

    



}

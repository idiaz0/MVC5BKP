using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FULL.Models
{
    // ⭐ NUEVA CLASE CONTENEDORA DE LA RESPUESTA DE LA API
    public class IgnitionApiResponse
    {
        [JsonPropertyName("user_source")]
        public string UserSource { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("usuarios")]
        public List<UsuarioViewModel> Usuarios { get; set; } = new List<UsuarioViewModel>();
    }

    public class UsuarioViewModel
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; } = string.Empty;

        [JsonPropertyName("rating")]
        public string Rating { get; set; } = string.Empty;

        [JsonPropertyName("flag")]
        public string Flag { get; set; } = string.Empty;

        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; } = new List<string>();

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("location")]
        public string Location { get; set; } = string.Empty;

        [JsonPropertyName("website")]
        public string Website { get; set; } = string.Empty;

        // 🌐 NUEVA PROPIEDAD MAPEADA DESDE LA API DE IGNITION
        [JsonPropertyName("language")]
        public string Language { get; set; } = string.Empty;

        // 🎖️ NUEVA PROPIEDAD MAPEADA DESDE LA API DE IGNITION
        [JsonPropertyName("badge")]
        public string Badge { get; set; } = string.Empty;

        [JsonPropertyName("updated_text")]
        public string UpdatedText { get; set; } = string.Empty;
    }
}

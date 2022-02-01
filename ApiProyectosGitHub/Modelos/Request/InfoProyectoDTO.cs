using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiProyectosGitHub.Modelos.Request
{
    public class InfoProyectoDTO
    {
        public string Url { get; set; } = string.Empty;
        public string TituloProyecto { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        public IFormFile File { get; set; }
    }
}

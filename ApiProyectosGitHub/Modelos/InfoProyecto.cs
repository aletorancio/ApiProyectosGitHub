using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyectosGitHub.Modelos
{
    public class InfoProyecto
    {
        internal RespuestaBD RespuestaBD { get; set; } = new RespuestaBD();
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string TituloProyecto { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public byte[] ImagenPresentacion { get; set; } 
        public DateTime FechaGuardado { get; set; } = DateTime.Now;
    }

    [NotMapped]
    public class RespuestaBD
    {
        public bool OK { get; set; } = true;
        public bool Error { get; set; } = false;
        public string Mensaje { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}

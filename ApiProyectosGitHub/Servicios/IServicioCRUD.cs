using ApiProyectosGitHub.Modelos;
using ApiProyectosGitHub.Modelos.Request;

namespace ApiProyectosGitHub.Servicios
{
    public interface IServicioCRUD
    {
        Task<List<InfoProyecto>> TraerInfoProyectoAsync();
        Task<InfoProyecto> EnviarInfoProyectoAsync(InfoProyectoDTO request);
        Task<InfoProyecto> ActualizarInfoProyectoAsync(InfoProyectoDTO request);
        Task<RespuestaBD> EliminarInfoProyectoAsync(int id);
    }
}

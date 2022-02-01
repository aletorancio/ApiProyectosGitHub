using ApiProyectosGitHub.Modelos;
using ApiProyectosGitHub.Modelos.Request;
using ApiProyectosGitHub.Servicios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProyectosGitHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProyectosGitHubController : ControllerBase
    {

        private readonly IServicioCRUD _servicioCRUD;
        public ApiProyectosGitHubController(IServicioCRUD servicioCRUD)
        {
            _servicioCRUD = servicioCRUD;
        }
        // GET: api/<ApiProyectosGitHubController>/mostrartodos
        [HttpGet("mostrartodos")]
        public async Task<IActionResult> MostrarTodos()
        {
            var respuesta = await _servicioCRUD.TraerInfoProyectoAsync();
            return Ok(respuesta);
        }

        // GET api/<ApiProyectosGitHubController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiProyectosGitHubController>/enviarinfo
        [HttpPost("enviarinfo")]
        public async Task<IActionResult> Enviar([FromForm] InfoProyectoDTO request)
        {
            var respuesta = await _servicioCRUD.EnviarInfoProyectoAsync(request);
            if (!respuesta.RespuestaBD.OK)
            {
                return BadRequest(respuesta.RespuestaBD);
            }
            return Ok(respuesta);
        }

        // PUT api/<ApiProyectosGitHubController>/5
        [HttpPut("actualizar")]
        public async Task<IActionResult> Actualizar([FromForm]InfoProyectoDTO request, [FromForm]int id)
        {
            var respuesta = await _servicioCRUD.ActualizarInfoProyectoAsync(request, id);
            if (!respuesta.RespuestaBD.OK)
            {
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // DELETE api/<ApiProyectosGitHubController>/5
        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Borrar(int id)
        {
            var respuesta = await _servicioCRUD.EliminarInfoProyectoAsync(id);
            if (!respuesta.OK)
            {
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }
    }
}

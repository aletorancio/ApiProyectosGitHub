using ApiProyectosGitHub.Data;
using ApiProyectosGitHub.Modelos;
using ApiProyectosGitHub.Modelos.Request;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiProyectosGitHub.Servicios.Implementacion
{
    public class ServicioCRUD : IServicioCRUD
    {
        private readonly DataContext _dataContext;
        public ServicioCRUD(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<InfoProyecto> ActualizarInfoProyectoAsync(InfoProyectoDTO request)
        {
            var resultado = new InfoProyecto()
            {
                Url = request.Url,
                Descripcion = request.Descripcion,
                TituloProyecto = request.TituloProyecto
            };
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    request.File.CopyTo(ms);
                    //Verifico que la imagen no sea mayor a 2MB
                    if (ms.Length < 2097152)
                    {
                        resultado.ImagenPresentacion = ms.ToArray();
                        _dataContext.InfoProyectos.Update(resultado);
                        await _dataContext.SaveChangesAsync();
                    }
                    else
                    {
                        resultado = new InfoProyecto();
                        resultado.RespuestaBD.OK = false;
                        resultado.RespuestaBD.Mensaje = "Error al guardar la imagen.";
                        resultado.RespuestaBD.Descripcion = "La imagen supera los 2 MB";
                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new InfoProyecto();
                resultado.RespuestaBD.OK = false;
                resultado.RespuestaBD.Mensaje = "Error al guardar el proyecto.";
                resultado.RespuestaBD.Descripcion = ex.Message;

                return resultado;
            }

            return resultado;
        }

        public async Task<RespuestaBD> EliminarInfoProyectoAsync(int id)
        {
            var respuesta = new RespuestaBD();
            var proyectaAborrar = await _dataContext.InfoProyectos.FindAsync(id);
            if (proyectaAborrar == null)
            {
                respuesta.OK = false;
                respuesta.Error = true;
                respuesta.Mensaje = "Error al borrar el proyecto.";
                respuesta.Descripcion = "El id a borrar no existe en la base de datos.";
                return respuesta;
            }
            else
            {
                _dataContext.InfoProyectos.Remove(proyectaAborrar);
                await _dataContext.SaveChangesAsync();
                respuesta.Mensaje = "Borrado";
                respuesta.Descripcion = "El proyecto ya no existe en la base de datos.";
            }

            return respuesta;
        }

        public async Task<InfoProyecto> EnviarInfoProyectoAsync(InfoProyectoDTO request)
        {
            var resultado = new InfoProyecto()
            {
                Url = request.Url,
                Descripcion = request.Descripcion,
                TituloProyecto = request.TituloProyecto
            };
            try
            {
                using(MemoryStream ms = new MemoryStream())
                {
                    request.File.CopyTo(ms);
                    //Verifico que la imagen no sea mayor a 2MB
                    if(ms.Length < 2097152)
                    {
                        resultado.ImagenPresentacion = ms.ToArray();
                        _dataContext.InfoProyectos.Add(resultado);
                        await _dataContext.SaveChangesAsync();
                    }
                    else
                    {
                        resultado = new InfoProyecto();
                        resultado.RespuestaBD.OK = false;
                        resultado.RespuestaBD.Mensaje = "Error al guardar la imagen.";
                        resultado.RespuestaBD.Descripcion = "La imagen supera los 2 MB";
                        return resultado;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = new InfoProyecto();
                resultado.RespuestaBD.OK = false;
                resultado.RespuestaBD.Mensaje = "Error al guardar el proyecto.";
                resultado.RespuestaBD.Descripcion = ex.Message;

                return resultado;
            }
            
            return resultado;
        }
        public async Task<List<InfoProyecto>> TraerInfoProyectoAsync()
        {
            var resultado = await _dataContext.InfoProyectos.ToListAsync();
            return resultado;
        }

    }
}

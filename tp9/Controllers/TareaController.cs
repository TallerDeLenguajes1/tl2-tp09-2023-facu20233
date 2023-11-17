using Microsoft.AspNetCore.Mvc;
using webApi.Repositorios;

namespace webApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private TareaRepository tareaRepository;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }

    [HttpPost("api/tarea")]
    public ActionResult<Tarea> CreateTarea(int idTablero, Tarea tarea){
        tareaRepository.Create(idTablero,tarea);
        return Ok(tarea);
    }

    [HttpPut("api/tarea/{id}/nombre/{nombre}")]
    public ActionResult<Tarea> UpdateTarea(int id, string nombre){
        var tarea = tareaRepository.Get(id);
        tarea.Nombre = nombre;
        tareaRepository.Update(id,tarea);
        return Ok(tarea);
    }
    [HttpPut("api/tarea/{id}/estado/{estado}")]
    public ActionResult<Tarea> UpdateEstado(int id, EstadoTarea estado){
        var tarea = tareaRepository.Get(id);
        tarea.Estado = estado;
        tareaRepository.Update(id,tarea);
        return Ok(tarea);
    }
    [HttpDelete("api/tarea/{id}")]
    public ActionResult<Tarea> DeleteTarea(int id){
        tareaRepository.Remove(id);
        return Ok();
    }
    [HttpGet("api/tarea/{estado}")]
    public ActionResult<Tarea> GetTareaPorEstado(int estado){
        int cant = tareaRepository.GetByEstado(estado).Count;
        return Ok(cant);
    }
    [HttpGet("api/tarea/usuario/{id}")]
    public ActionResult<List<Tarea>> GetTareaPorUser(int id){
        var tareas = tareaRepository.GetByUser(id);
        return Ok(tareas);
    }
    [HttpGet("api/tarea/tablero/{id}")]
    public ActionResult<List<Tarea>> GetTareaPorTablero(int id){
        var tareas = tareaRepository.GetByTablero(id);
        return Ok(tareas);
    }

    

}
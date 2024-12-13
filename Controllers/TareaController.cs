using Microsoft.AspNetCore.Mvc;

namespace practicaRecuperacionTaller2.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly TareaRepository _tareaRepository;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        _tareaRepository = new TareaRepository("Data Source=Db/Tareas.db;Cache=Shared");
    }
    [HttpPost("/api/Tarea")]
    public ActionResult<Tarea> Create([FromBody]Tarea tarea){
       bool tareaCreada= _tareaRepository.CrearTarea(tarea);
       if(!tareaCreada) return BadRequest("No se pudo crear la tarea");
       return Created(); 
    }
    [HttpGet("/api/tarea/{id}")]
    public ActionResult<Tarea> GetTarea(int id){
        Tarea tarea= _tareaRepository.BuscarTareaPorId(id);
        if (tarea == null) return NotFound("No se encontro la tarea");
        return Ok(tarea);
    }
    [HttpDelete("/api/tarea/{id}")]
    public ActionResult<Tarea> DeleteTarea(int id){
        bool tareaEliminar= _tareaRepository.Delete(id);
        if (!tareaEliminar) return BadRequest("No se pudo eliminar la tarea");
        return Ok("Tarea Borrada con exito");
    }
}

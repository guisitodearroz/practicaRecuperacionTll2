using Microsoft.AspNetCore.Mvc;

namespace practicaRecuperacionTaller2.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly ITareaRepository _tareaRepository;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger, ITareaRepository tareaRepository)
    {
        _logger = logger;
        _tareaRepository = tareaRepository;
    }
    [HttpPost("/api/Tarea")]
    public ActionResult<Tarea> Create([FromBody]CrearTareaViewModels tarea_vm){
        if (!ModelState.IsValid) return BadRequest("no se puede guardar por falta de datos");
        Tarea tarea= new Tarea(tarea_vm);
       bool tareaCreada= _tareaRepository.CrearTarea(tarea);
       if(!tareaCreada) return BadRequest("No se pudo crear la tarea");
       return Created(); 
    }
    [HttpGet("/api/tarea/{id}")]
    public ActionResult<GetTareaViewModels> GetTarea(int id){
        Tarea tarea= _tareaRepository.BuscarTareaPorId(id);
        if (tarea == null) return NotFound("No se encontro la tarea");
        GetTareaViewModels tarea_vm= new GetTareaViewModels(tarea);
        return Ok(tarea_vm);
    }
    [HttpDelete("/api/tarea/{id}")]
    public ActionResult<Tarea> DeleteTarea(int id){
        bool tareaEliminar= _tareaRepository.Delete(id);
        if (!tareaEliminar) return BadRequest("No se pudo eliminar la tarea");
        return Ok("Tarea Borrada con exito");
    }
    [HttpPut("/api/tarea/{id}")]
    public ActionResult<Tarea> UpdateTarea(int id, Tarea tarea){
        bool tareaActualizada= _tareaRepository.Update(id,tarea);
        if (!tareaActualizada) return BadRequest("No se pudo actualizar la tarea");
        return Ok("Ya actualizaste crack");
    }
}

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
       return NoContent(); 
    }
    
}

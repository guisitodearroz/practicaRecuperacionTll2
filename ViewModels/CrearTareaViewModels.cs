using System.ComponentModel.DataAnnotations;

public class CrearTareaViewModels
{
    public CrearTareaViewModels(){
    }
    [Required]
    public string Titulo {get; set;}
    [Required]
    public string Descripcion {get;set;}
    [Required]
    public Estado Estado {get; set;}
}
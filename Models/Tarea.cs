public class Tarea
{
    private int id;
    private string titulo;
    private string descripcion;
    private Estado estado;
    public Tarea(int id, string titulo, string descripcion, Estado estado)
    {
        Id = id;
        Titulo = titulo;
        Descripcion = descripcion;
        Estado = estado;
    }

    public int Id {get=> id ; set =>id = value;}
    public string Titulo {get=> titulo; set=>titulo = value;}
    public string Descripcion {get=> descripcion; set=>descripcion = value;}
    public Estado Estado {get=> estado; set=>estado = value;}
    public Tarea(CrearTareaViewModels tareaVM)
    {
        titulo= tareaVM.Titulo;
        descripcion=tareaVM.Descripcion;
        estado= tareaVM.Estado;
    }

    public Tarea()
    {
    }
}
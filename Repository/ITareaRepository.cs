public interface ITareaRepository
{
    public bool CrearTarea(Tarea tarea){
        return false;
    }
    public Tarea BuscarTareaPorId(int id){
        return new Tarea();
    }
    public bool Delete(int id){
        return false;
    }
    public bool Update(int id, Tarea tarea){
        return false;
    }
}
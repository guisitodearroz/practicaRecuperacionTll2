using Microsoft.Data.Sqlite;

public class TareaRepository
{
    //crea un campo para tener la direccion de la conexion a la Bd
    private string _cadenaConexion;
    public TareaRepository(string cadenaConexion){
        _cadenaConexion= cadenaConexion;
    }
    //comienzo con las consultas
    public bool CrearTarea(Tarea tarea){
        string query ="INSERT INTO tareas(titulo,descripcion,estado) VALUES(@titulo,@descripcion,@estado)";
        int cantFilasModif=0;
        using (SqliteConnection conexion= new SqliteConnection(_cadenaConexion)){
            conexion.Open();
            SqliteCommand comando= new SqliteCommand(query,conexion);
            comando.Parameters.Add(new SqliteParameter("@titulo", tarea.Titulo));
            comando.Parameters.Add(new SqliteParameter("@descripcion",tarea.Descripcion));
            comando.Parameters.Add(new SqliteParameter("@estado",tarea.Estado));
            cantFilasModif= comando.ExecuteNonQuery();
            conexion.Close
        }
        return cantFilasModif > 0;
    }
}
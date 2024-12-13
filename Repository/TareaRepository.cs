using Microsoft.Data.Sqlite;

public class TareaRepository : ITareaRepository
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
            conexion.Close();
        }
        return cantFilasModif > 0;
    }

    public Tarea BuscarTareaPorId(int id){
        string query ="SELECT * FROM tareas WHERE id= @id";
        Tarea tarea=null;
        using (SqliteConnection conexion= new SqliteConnection(_cadenaConexion)){
            conexion.Open();
            SqliteCommand comando= new SqliteCommand(query, conexion);
            comando.Parameters.Add(new SqliteParameter("@id", id));
            using(SqliteDataReader reader= comando.ExecuteReader()){
                if (reader.Read())
                {
                    tarea= new Tarea{
                        Id=Convert.ToInt32(reader["id"]),
                        Titulo= reader["titulo"].ToString(),
                        Descripcion= reader["descripcion"].ToString(),
                        Estado= (Estado)Convert.ToInt32(reader["estado"])
                    };
                }
            }
            conexion.Close();
        }
        return tarea;

    }

    public bool Delete(int id){
        string query="DELETE FROM tareas WHERE = id= @id";
        int cantfilas=0;
        using(SqliteConnection conexion= new SqliteConnection(_cadenaConexion)){
            conexion.Open();
            SqliteCommand comando= new SqliteCommand(query, conexion);
            comando.Parameters.Add(new SqliteParameter("@id", id));
            cantfilas= comando.ExecuteNonQuery();
            conexion.Close();
        }
        return cantfilas > 0;
    }
    public bool Update(int id, Tarea tarea){
        string query="UPDATE tareas SET titulo= @titulo ,descripcion= @descripcion,estado=@estado WHERE id= @id";
        int cantfilas=0;
        using(SqliteConnection conexion= new SqliteConnection(_cadenaConexion)){
            conexion.Open();
            SqliteCommand comando= new SqliteCommand(query, conexion);
            comando.Parameters.Add(new SqliteParameter("@titulo",tarea.Titulo));
            comando.Parameters.Add(new SqliteParameter("@descricion",tarea.Descripcion));
            comando.Parameters.Add(new SqliteParameter("@estado",tarea.Estado));
            cantfilas= comando.ExecuteNonQuery();
            conexion.Close();
        } 
        return cantfilas > 0;
    }
}
// EF Database First
// DbContext son objetos de tipo Resource (Open, Close)
using EfOrmNet;

using (var db = new SqliteDbContext())
{
    // consulta a la tabla editoriales para obtener todos los registros
    // SELECT * FROM Editoriales;
    var editoriales = db.Editoriales.ToList();
    foreach(var editorial in editoriales)
    {
        Console.WriteLine("Id:{0} Nombre:{1}", editorial.Id, editorial.Nombre);
    }
}
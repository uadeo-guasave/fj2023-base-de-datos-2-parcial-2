namespace EfOrmNet;

using System;
// EF Database First
// DbContext son objetos de tipo Resource (Open, Close)
using EfOrmNet.Models;

class Program
{
    static void Main(string[] args)
    {
        SelectEditoriales();
        // InsertEditorial();
        // SelectEditoriales();
        var editorial = BuscarEditorialPorId(2);
        if (editorial != null)
        {
            using (var db = new SqliteDbContext())
            {
                var e = db.Editoriales.Find(editorial.Id);
                e.Nombre = "Nuevo nombre";
                db.SaveChanges();
            }
        }
        SelectEditoriales();
    }

    private static Editorial BuscarEditorialPorId(int id)
    {
        using (var db = new SqliteDbContext())
        {
            var editorial = db.Editoriales.Find(id);
            return editorial;
        }
    }

    private static void InsertEditorial()
    {
        using (var db = new SqliteDbContext())
        {
            // guardar una nueva editorial
            var editorial = new Editorial
            {
                Nombre = "Nevaska",
                CorreoElectronico = "ana.soberanes@nevaska.com",
                Telefono = "6372926460"
            };
            db.Editoriales.Add(editorial);
            db.SaveChanges();
        }
    }

    private static void SelectEditoriales()
    {
        using (var db = new SqliteDbContext())
        {
            // consulta a la tabla editoriales para obtener todos los registros
            // SELECT * FROM Editoriales;
            var editoriales = db.Editoriales.ToList();
            foreach (var editorial in editoriales)
            {
                Console.WriteLine("Id:{0} Nombre:{1}", editorial.Id, editorial.Nombre);
            }
        }
    }
}
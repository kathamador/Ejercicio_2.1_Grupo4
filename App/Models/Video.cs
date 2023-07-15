using SQLite;

namespace App.Models
{
    public class Video
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;

        public string NombreVideo { get; set; }

        public string Ubicacion { get; set; }
    }
}

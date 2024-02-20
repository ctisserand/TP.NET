using System.Collections.Generic;

namespace ASP.Server.Dtos
{
    public class BookListDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Auteur { get; set; }
        public double Prix { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
    }
}

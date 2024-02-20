using System.Collections;

namespace ASP.Server.Models
{
    public class Auteur
    {

        public int Id { get; set; }
        public string Nom { get; set; }

        public IEnumerable Livres { get; set; }
    }
}

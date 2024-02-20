using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Server.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public IEnumerable<Book> Livres { get; set; }
    }
}

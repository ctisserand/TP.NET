using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Reader.Model
{
    public class Genre
    {
        public String Nom { get; set; }
        public int IdGenre { get; set; }

        public List<Book> Livres { get; set; }
        public Genre(string nom, int id)
        {
            Nom = nom;
            IdGenre = id;
        }
        public Genre() { }
    }
}

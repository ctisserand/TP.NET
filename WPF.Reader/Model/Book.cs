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
  
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du livre est requis.")]
        public String Nom { get; set; }

        [Required(ErrorMessage = "Le nom de l'auteur est requis.")]
        public String Auteur { get; set; }
        public double Prix { get; set; }

        [Required(ErrorMessage = "Le contenu du livre est requis.")]
        public String Contenu { get; set; }

    }
}

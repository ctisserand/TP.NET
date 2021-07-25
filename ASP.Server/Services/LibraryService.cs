using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Server.Service
{
    class LibraryService
    {
        private static LibraryService instance;
        public static LibraryService Instance { get
            {
                if (instance == null)
                    instance = new LibraryService();
                return instance;
            }
        }

        // Ajouter ici toutes vos fonctions qui peuvent être accéder a différent endroit de votre programme
    }
}

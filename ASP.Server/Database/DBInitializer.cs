using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre SF, Classic, Romance, Thriller,Autobiography;
            bookDbContext.Genre.AddRange(
                SF = new Genre() { Nom = "Science Fiction" },
                Classic = new Genre() { Nom = "Classic"},
                Romance = new Genre() { Nom = "Romance" },
                Thriller = new Genre() { Nom = "Thriller" },
                Autobiography = new Genre() { Nom = "Autobiography" }

            );

            Auteur Yessine, Saad, Hugo, Laurent, Theo;
            bookDbContext.Auteurs.AddRange(
                Yessine = new Auteur() { Nom = "Yessine" },
                Saad = new Auteur() { Nom = "Saad" },
                Hugo = new Auteur() { Nom = "Hugo" },
                Laurent = new Auteur() { Nom = "Laurent" },
                Theo = new Auteur() { Nom = "Theo" }

            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { Auteur = Hugo, Nom = "Epique", Prix = 12.5f, Contenu = "Emmanuel Petit, né le 22 septembre 1970 à Dieppe (Seine-Maritime), est un footballeur international français. Il évolue au poste de milieu récupérateur et parfois comme défenseur central ou arrière gauche de 1988 à 2004.\r\n\r\nRévélé très tôt à l'AS Monaco, ce gaucher athlétique fut l'un des cadres de l'équipe de France qui a remporté la Coupe du monde 1998 et l'Euro 2000. Il est particulièrement célèbre pour avoir marqué le dernier but de la victoire des Bleus en finale de la Coupe du monde 1998 contre le Brésil qui fut aussi le 1000e but de l'équipe de France.", Genres = new() { Thriller } },
                new Book() { Auteur = Saad, Nom = "Machin", Prix = 10.5f, Contenu = "Laurent Blanc, né le 19 novembre 1965 à Alès (Gard), est un ancien footballeur international français, reconverti en entraîneur. Il est actuellement en poste à l'Olympique lyonnais.\r\n\r\nIl a évolué majoritairement au poste de défenseur du début des années 1980 au début des années 2000.\r\n\r\nCe défenseur au profil très offensif, est formé à l'origine comme meneur de jeu au Montpellier HSC où il reste huit saisons, il évolue ensuite au SSC Naples, au Nîmes Olympique, à l'AS Saint-Étienne sans succès avant de rejoindre l'AJ Auxerre avec laquelle il gagne le championnat de France en 1996. Il rejoint alors le FC Barcelone puis l'Olympique de Marseille et l'Inter Milan avant de terminer sa carrière à Manchester United sur un titre de champion d'Angleterre en 2003.\r\n\r\nSurnommé « le Président », il compte 97 sélections en équipe de France, pour 16 buts inscrits. Il est un des cadres de la sélection qui remporte la Coupe du monde 1998 et le championnat d'Europe 2000. Il est auparavant vainqueur du championnat d'Europe espoirs 1988.\r\n\r\nAprès sa carrière de joueur, il poursuit une carrière d'entraîneur aux Girondins de Bordeaux à partir de 2007 et remporte le titre de champion de France en 2009. En mai 2010, il est désigné par la Fédération française de football pour succéder à Raymond Domenech en tant que sélectionneur de l'équipe de France après la Coupe du monde en Afrique du Sud. Il quitte ses fonctions deux ans plus tard après le quart de finale de l'Euro 2012.\r\n\r\nÀ partir de juin 2013, il est l'entraîneur du Paris Saint-Germain avec lequel il remporte notamment la Ligue 1 en 2014, 2015 et 2016. Il réalise même un quadruplé historique (Ligue 1, la Coupe de France, la Coupe de la Ligue et le Trophée des champions) ces deux dernières années. À la suite d'échecs répétés en quarts de finale de Ligue des champions, son contrat est résilié en juin 2016.", Genres = new() { Classic, Thriller } },
                new Book() { Auteur = Yessine, Nom = "Truc", Prix = 13.5f, Contenu = "Zinédine Zidane, né le 23 juin 1972 à Marseille, est un footballeur international français évoluant au poste de milieu offensif, comme meneur de jeu devenu entraîneur.\r\n\r\nSurnommé Zizou, il est considéré comme l'un des plus grands joueurs de l'histoire du football. Doté d'un profil atypique, il remporte de nombreux titres, tant avec l'équipe de France qu'avec les clubs où il a joué, comme les Girondins de Bordeaux, la Juventus et le Real Madrid. Il a, de plus, été nommé meilleur joueur de l'année au moins une fois dans chaque championnat où il a évolué.\r\n\r\nZidane est, selon la BBC, le meilleur joueur européen de l'histoire. Il est désigné meilleur joueur européen des cinquante dernières années par l'UEFA en 2004. Il est cité parmi les 125 meilleurs joueurs mondiaux encore vivants en 2004, dans un classement conjoint de Pelé et de la FIFA. Il est à trois reprises nommé meilleur joueur mondial de l'année par la FIFA, en 1998, 2000 et 2003, et remporte le Ballon d'or 1998. S'il est par deux fois classé second meilleur joueur français de tous les temps par France Football, il est pour L'Équipe le meilleur footballeur français de l'histoire. En 2011 il est élu meilleur joueur de la Ligue des champions des vingt dernières années par l'UEFA. Membre de l'équipe UEFA du xxie siècle, du Onze des Légendes de l'Euro (meilleure équipe de l'histoire du Championnat d'Europe), de la FIFA World Cup Dream Team (meilleure équipe de l'histoire de la Coupe du monde) et de la Dream Team World Soccer (meilleure équipe de l'histoire), Zinédine Zidane a, en outre, été élu meilleur joueur de la décennie 2000 par Marca, Sports Illustrated, Fox Sports, ESPN et Don Balón.\r\n\r\nSélectionné à 108 reprises et 25 fois capitaine de l'équipe de France, Zinédine Zidane s'illustre principalement au niveau international lors de la victoire à la Coupe du monde 1998 où il marque deux buts de la tête lors de la finale gagnée 3 buts à 0 contre le Brésil, au championnat d'Europe 2000 également remporté, et à la Coupe du monde 2006 où ses exploits portent la France en finale.\r\n\r\nCélèbre numéro 10 des « Bleus », surnommé « El Magnifico », il met un terme à sa carrière à la suite de la Coupe du monde 2006, au cours de laquelle il se distingue et obtient le titre de meilleur joueur du Mondial. Le 9 juillet 2006, il joue son dernier match à l'occasion de la finale de la Coupe du monde opposant l'Italie à la France. Il s'y illustre de manière ambivalente en inscrivant son trente-et-unième but sous le maillot français par une panenka réussie, mais aussi par son expulsion sur carton rouge pour son coup de tête au thorax de Marco Materazzi.\r\n\r\nAprès sa retraite de joueur, Zidane passe avec succès ses diplômes d’entraîneur puis devient l’adjoint de Carlo Ancelotti au Real en 2013-14. L’année suivante, il prend en main l’équipe réserve du Castilla avant d’être nommé en janvier 2016 entraîneur en chef de l’équipe première après le limogeage de Rafael Benítez. Lors de ses deux premières saisons, il remporte deux fois la Ligue des Champions, un championnat, une Supercoupe d’Espagne, deux Supercoupes d’Europe et deux Mondial des Clubs. Durant cette période, il bat plusieurs records d’invincibilité et est élu meilleur entraîneur mondial de l'année. Il devient ainsi le premier homme de l'histoire du football à remporter le prix de meilleur joueur et de meilleur entraîneur du monde. En 2018, Zidane mène le Real Madrid vers une nouvelle victoire en Ligue des Champions, devenant le premier entraîneur à la remporter trois fois consécutivement. Quelques jours après la victoire, il quitte son poste salué par l’ensemble des observateurs et de la profession. En mars 2019, il est rappelé au poste d'entraîneur par le président Florentino Pérez après le limogeage de Santiago Solari, et remporte une deuxième Liga à la tête de son équipe, au terme de la saison 2019-2020. À l'issue de la saison 2020-2021, le 27 mai, il quitte son poste d'entraîneur du Real.", Genres = new() { Classic, Romance } },
                new Book() { Auteur = Laurent, Nom = "Truc du truc", Prix = 15.5f, Contenu = "caeaze", Genres = new() { Classic, Thriller, Romance } }
            ); ;
            // Vous pouvez initialiser la BDD ici

            bookDbContext.SaveChanges();
        }
    }
}
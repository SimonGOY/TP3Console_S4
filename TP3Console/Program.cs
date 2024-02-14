using Microsoft.EntityFrameworkCore;
using TP3Console.Models.EntityFramework;
using System.Linq;
using System.Globalization;

namespace TP3Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action
                Categorie categorieAction = ctx.Categories.First(c => c.Nom == "Action");
                Console.WriteLine("Categorie : " + categorieAction.Nom);
                Console.WriteLine("Films : ");
                //Chargement des films de la catégorie Action.
                foreach (var film in categorieAction.Films) // lazy loading initiated
                {
                    Console.WriteLine(film.Nom);
                }
            }*/

            /*using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action, des films de cette catégorie et des avis
                Categorie categorieAction = ctx.Categories
                .Include(c => c.Films)
                .ThenInclude(f => f.Avis)
                .First(c => c.Nom == "Action");
            }*/

            Exo2Q9();

            Console.ReadKey();
        }
        public static void Exo2Q1()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Films)
            {
                Console.WriteLine(film.ToString());
            }
        }

        //Autre possibilité :
        public static void Exo2Q1Bis()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes que les classes c#.
            var films = ctx.Films.FromSqlRaw("SELECT * FROM film");
            foreach (var film in films)
            {
                Console.WriteLine(film.ToString());
            }
        }
        public static void Exo2Q2()
        {
            var ctx = new FilmsDBContext();
            foreach (var utilisateur in ctx.Utilisateurs)
            {
                Console.WriteLine(utilisateur.Email);
            }
        }

        public static void Exo2Q3()
        {
            var ctx = new FilmsDBContext();
            foreach(var utilisateur in ctx.Utilisateurs.OrderBy(u => u.Login))
            {
                Console.WriteLine(utilisateur.Login);
            }
        }

        public static void Exo2Q4()
        {
            var ctx = new FilmsDBContext();
            foreach(var films  in ctx.Films.Where(s=>s.Categorie == 1))
            {
                Console.WriteLine(films.ToString());
            }
        }

        public static void Exo2Q5()
        {
            var ctx = new FilmsDBContext();
            int nb = 0;
            foreach(var categorie in ctx.Categories)
            {
                nb++;
            }
            Console.WriteLine("Il y a "+ nb + " catégories");
        }

        public static void Exo2Q6()
        {
            var ctx = new FilmsDBContext();
            Console.WriteLine("La note la plus basse est la : " + ctx.Avis.Min(s => s.Note));
        }

        public static void Exo2Q7()
        {
            var ctx = new FilmsDBContext();
            var films = ctx.Films.Where(s => s.Nom.ToUpper().StartsWith("LE"));
            foreach(var film in films)
            {
                Console.WriteLine(film.Nom);
            }
        }

        public static void Exo2Q8()
        {
            var ctx = new FilmsDBContext();
            Film id_film = ctx.Films.First(s => s.Nom.ToUpper() == "PULP FICTION");
            ctx.Entry(id_film).Collection(s => s.Avis).Load();
            Console.WriteLine(id_film.Avis.Average(s => s.Note));
        }

        public static void Exo2Q9()
        {
            var ctx = new FilmsDBContext();
            Console.WriteLine(ctx.Utilisateurs.First(s => s.Id == ctx.Avis.First(s=>s.Note == ctx.Avis.Max(s=>s.Note)).Utilisateur));
        }
    }
}
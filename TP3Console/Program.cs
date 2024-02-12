using Microsoft.EntityFrameworkCore;
using TP3Console.Models.EntityFramework;

namespace TP3Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action, des films de cette catégorie et des avis
                Categorie categorieAction = ctx.Categories
                .Include(c => c.Films)
                .ThenInclude(f => f.Avis)
                .First(c => c.Nom == "Action");
            }
            Console.ReadKey();
        }

    }
}
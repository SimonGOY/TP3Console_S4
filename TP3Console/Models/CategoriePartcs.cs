using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Console.Models.EntityFramework
{
    partial class Categorie
    {
        public override string? ToString()
        {
            return "Nom : " + this.Nom + ", Description : " + this.Description;
        }
    }
}

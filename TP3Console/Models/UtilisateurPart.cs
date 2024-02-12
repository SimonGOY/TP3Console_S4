using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Console.Models.EntityFramework
{
    partial class Utilisateur
    {
        public override string? ToString()
        {
            return "Email : " + this.Email + ", Login : " + this.Login + ", Email : " + this.Email;
        }
    }
}

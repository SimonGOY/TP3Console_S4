using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TP3Console.Models.EntityFramework
{
    [Table("avis")]
    public partial class Avi
    {
        [Key]
        [Column("film")]
        public int Film { get; set; }
        [Key]
        [Column("utilisateur")]
        public int Utilisateur { get; set; }
        [Column("avis")]
        public string? Avis { get; set; }
        [Column("note")]
        public decimal Note { get; set; }

        [ForeignKey("Film")]
        [InverseProperty("Avis")]
        public virtual Film FilmNavigation { get; set; } = null!;
        [ForeignKey("Utilisateur")]
        [InverseProperty("Avis")]
        public virtual Utilisateur UtilisateurNavigation { get; set; } = null!;
    }
}

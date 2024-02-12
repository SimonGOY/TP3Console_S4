using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TP3Console.Models.EntityFramework
{
    [Table("utilisateur")]
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Avis = new HashSet<Avi>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("login")]
        [StringLength(50)]
        public string Login { get; set; } = null!;
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; } = null!;
        [Column("pwd")]
        [StringLength(50)]
        public string Pwd { get; set; } = null!;

        [InverseProperty("UtilisateurNavigation")]
        public virtual ICollection<Avi> Avis { get; set; }
    }
}

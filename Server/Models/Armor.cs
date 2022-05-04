using System.ComponentModel.DataAnnotations;

namespace RPGCharacterBuilderWebApp1.Server.Models
{
    public class Armor
    {
        [Key]
        public int Id { get; set; }
        // [Required]
        // public int CharacterId { get; set; }
        [Required]
        public string Name { get; set; }
        // [Required]
        // public string Type { get; set; }
        // [Required]
        // public int DamageNegation { get; set; }
        // [Required]
        // public int Weight { get; set; }

        //public virtual Character Character { get; set; }
    }
}

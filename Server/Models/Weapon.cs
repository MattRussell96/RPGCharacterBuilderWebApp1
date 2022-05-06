using System.ComponentModel.DataAnnotations;

namespace RPGCharacterBuilderWebApp1.Server.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int DamageIncreasedBy { get; set; }
        [Required]
        public int MagicDamage { get; set; }
        [Required]
        public int Weight { get; set; }
    }
}

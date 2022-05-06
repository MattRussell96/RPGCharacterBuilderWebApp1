using System.ComponentModel.DataAnnotations;

namespace RPGCharacterBuilderWebApp1.Server.Models
{
    public class MagicItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int MagicDamageIncreasedBy { get; set; }
        [Required]
        public int Weight { get; set; }
    }
}

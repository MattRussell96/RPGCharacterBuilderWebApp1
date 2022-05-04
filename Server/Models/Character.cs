using System;
using System.ComponentModel.DataAnnotations;

namespace RPGCharacterBuilderWebApp1.Server.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Health { get; set; }
        [Required]
        public int Strength { get; set; }
        [Required]
        public int Stamina { get; set; }
        [Required]
        public int Speed { get; set; }
        [Required]
        public int Mana { get; set; }
        public int ArmorId { get; set; }
        public virtual Armor Armor { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        //public virtual MagicItem MagicItems { get; set; }
        //public virtual Weapon Weapons { get; set; }
    }
}

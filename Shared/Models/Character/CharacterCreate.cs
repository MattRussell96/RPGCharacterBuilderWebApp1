using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Shared.Models.Character
{
    public class CharacterCreate
    {
        [Required]
        public int Id { get; set; }
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
    }
}

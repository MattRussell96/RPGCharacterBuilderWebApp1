using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Shared.Models.Weapon
{
    public class WeaponCreate
    {
        [Required]
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

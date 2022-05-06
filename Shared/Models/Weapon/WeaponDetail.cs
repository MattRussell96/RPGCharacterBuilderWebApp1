using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Shared.Models.Weapon
{
    public class WeaponDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int DamageIncreasedBy { get; set; }
        public int MagicDamage { get; set; }
        public int Weight { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Shared.Models.Armor
{
    public class ArmorDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int DamageNegation { get; set; }
        public int Weight { get; set; }

    }
}

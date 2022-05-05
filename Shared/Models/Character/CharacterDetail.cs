using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Shared.Models.Character
{
    public class CharacterDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Speed { get; set; }
        public int Mana { get; set; }
        public int ArmorId { get; set; }
        public string ArmorName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

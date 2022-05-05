using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Shared.Models.Character
{
    public class CharacterListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArmorName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

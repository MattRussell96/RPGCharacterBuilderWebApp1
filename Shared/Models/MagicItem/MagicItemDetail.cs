using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Shared.Models.MagicItem
{
    public class MagicItemDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int MagicDamageIncreasedBy { get; set; }
        public int Weight { get; set; }
    }
}

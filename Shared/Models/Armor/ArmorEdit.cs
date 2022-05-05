using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacterBuilderWebApp1.Shared.Models.Armor
{
    public class ArmorEdit
    {
        [Required]
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Models.HoleModels
{
    public class HoleCreate
    {
        [Required]
        public int HoleNumber { get; set; }
        public string HoleDescription { get; set; }
    }
}

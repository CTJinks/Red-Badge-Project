using DiscGolf.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Models.HoleModels
{
    public class HoleListItem
    {
        public int HoleId { get; set; }
        public int HoleNumber { get; set; }
        public string HoleDescription { get; set; }
        public virtual Course Course { get; set; }
    }
}

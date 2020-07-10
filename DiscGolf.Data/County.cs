using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Data
{
    public class County
    {
        [Key]
        public int CountyId { get; set; }
        [Required]
        public string CountyName { get; set; }
        
    }
}

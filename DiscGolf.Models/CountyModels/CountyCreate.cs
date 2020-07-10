using DiscGolf.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Models.CountyModels
{
    public class CountyCreate
    {
        [Required]
        public string CountyName { get; set; }
    }
}

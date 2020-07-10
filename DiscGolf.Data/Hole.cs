using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Data
{
    public class Hole
    {
        [Key]
        public int HoleId { get; set; }
        [Required]
        public int HoleNumber { get; set; }
        public string HoleDescription { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course Course { get; set; }
    }
}

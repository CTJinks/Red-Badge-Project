using DiscGolf.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Data
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseLocation { get; set; }
        public string CourseDescription { get; set; }
        [ForeignKey("County")]
        public int? CountyId { get; set; }
        public virtual County County { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}

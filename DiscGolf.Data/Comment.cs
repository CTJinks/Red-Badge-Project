using DiscGolf.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Models.CourseModels
{
    public class Comment
    { 
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey("AppUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser AppUser { get; set; }

    }
}

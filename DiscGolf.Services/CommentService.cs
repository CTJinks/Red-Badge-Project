using DiscGolf.Data;
using DiscGolf.Models.CommentModels;
using DiscGolf.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Services
{
    public class CommentService
    {
        private readonly string _userId;
        public CommentService(string userId)
        {
            _userId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    ApplicationUserId = _userId,
                    Text = model.Text,
                    CourseId = model.CourseId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    UserName = e.AppUser.UserName,
                                    CourseName = e.Course.CourseName,
                                    Text = e.Text
                                }
                        );
                var array = query.ToArray();
                return array;
            }
        }
        public IEnumerable<CommentListItem> SortComments(string sortOrder, string searchString)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comments = from s in ctx.Comments
                              select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    comments = comments.Where(s => s.Course.CourseName.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        comments = comments.OrderByDescending(s => s.CommentId);
                        break;
                    case "courseName":
                        comments = comments.OrderBy(s => s.Course.CourseName);
                        break;
                    case "courseName_desc":
                        comments = comments.OrderByDescending(s => s.Course.CourseName);
                        break;
                    default:
                        comments = comments.OrderBy(s => s.CommentId);
                        break;
                }
                return (comments.Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    UserName = e.AppUser.UserName,
                                    CourseName = e.Course.CourseName,
                                    Text = e.Text
                                }
                        ).ToList());
            }
        }
        /*public List<CommentDetail> GetCommentByCourse(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Where(e => e.Course.CourseId == id);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        Text = entity.Text,
                        CourseName = entity.Course.CourseName,
                        UserName = entity.UserName
                    };
            }

        }*/
        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        UserName = entity.AppUser.UserName,
                        Text = entity.Text,
                        CourseName = entity.Course.CourseName
                    };
            }
        }
    }
}

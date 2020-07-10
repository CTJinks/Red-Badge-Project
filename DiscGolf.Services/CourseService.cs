using DiscGolf.Data;
using DiscGolf.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Services
{
    public class CourseService
    {
        public bool CreateCourse(CourseCreate model)
        {
            var entity =
                new Course()
                {
                    CourseName = model.CourseName,
                    CourseLocation = model.CourseLocation,
                    CourseDescription = model.CourseDescription,
                    CountyId = model.CountyId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CourseListItem> GetCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Courses
                        .Select(
                            e =>
                                new CourseListItem
                                {
                                    CourseId = e.CourseId,
                                    CourseLocation = e.CourseLocation,
                                    CourseName = e.CourseName,
                                    CourseDescription = e.CourseDescription,
                                    CountyName = e.County.CountyName
                                }
                        );
                var array = query.ToArray();
                return array;
            }
        }
        public CourseDetail GetCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Courses
                        .Single(e => e.CourseId == id);
                return
                    new CourseDetail
                    {
                        CourseId = entity.CourseId,
                        CourseLocation = entity.CourseLocation,
                        CourseName = entity.CourseName,
                        CourseDescription = entity.CourseDescription,
                        CountyName = entity.County.CountyName,
                     
                        
                    };
            }
        }
    }
}

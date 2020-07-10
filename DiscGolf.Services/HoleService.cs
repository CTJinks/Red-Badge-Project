using DiscGolf.Data;
using DiscGolf.Models.HoleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscGolf.Services
{
    public class HoleService
    {
        public bool CreateHole(HoleCreate model)
        {
            var entity =
                new Hole()
                {
                    HoleNumber = model.HoleNumber,
                    HoleDescription = model.HoleDescription
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Holes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<HoleListItem> GetHoles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Holes
                        .Select(
                            e =>
                                new HoleListItem
                                {
                                    HoleId = e.HoleId,
                                    HoleNumber = e.HoleNumber,
                                    HoleDescription = e.HoleDescription,
                                    Course = e.Course
                                }
                        );

                return query.ToArray();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StudentMarksDashBoardAPI.Models;

namespace StudentMarksDashBoardAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Score> scores { get; set; }

        public DbSet<SubjectModule> subjectModules { get; set; }

        public DbSet<Status> statuses { get; set; }


    }
}

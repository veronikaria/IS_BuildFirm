using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IS_BuildFirm.Models
{
    public class ApplicationContext :  IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Brigade> Brigades { get; set; }
        public DbSet<Builder> Builders { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}

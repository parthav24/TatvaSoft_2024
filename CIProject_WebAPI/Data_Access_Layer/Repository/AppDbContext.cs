using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Data_Access_Layer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<MissionSkill> MissionSkill { get; set; }
        public DbSet<MissionTheme> MissionTheme { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Missions> Missions { get; set; }
        public DbSet<MissionApplication> MissionApplication { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }
        public DbSet<MissionFavourites> MissionFavourites { get; set; }
        public DbSet<MissionComment> MissionComment { get; set; }
        public DbSet<Story> Story { get; set; }
        public DbSet<VolunteeringHours> VolunteeringHours { get; set; }
        public DbSet<VolunteeringGoals> VolunteeringGoals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", "CIProject");
            modelBuilder.Entity<UserDetail>().ToTable("UserDetail", "CIProject");
            modelBuilder.Entity<MissionSkill>().ToTable("MissionSkill", "CIProject");
            modelBuilder.Entity<MissionTheme>().ToTable("MissionTheme", "CIProject");
            modelBuilder.Entity<City>().ToTable("City", "CIProject");
            modelBuilder.Entity<Missions>().ToTable("Missions", "CIProject");
            modelBuilder.Entity<MissionApplication>().ToTable("MissionApplication", "CIProject");
            modelBuilder.Entity<Country>().ToTable("Country", "CIProject");
            modelBuilder.Entity<UserSkills>().ToTable("UserSkills", "CIProject");
            modelBuilder.Entity<ContactUs>().ToTable("ContactUs", "CIProject");
            modelBuilder.Entity<MissionComment>().ToTable("Comments", "CIProject");
            modelBuilder.Entity<Story>().ToTable("Story", "CIProject");
            modelBuilder.Entity<VolunteeringHours>().ToTable("VolunteeringHours", "CIProject");
            modelBuilder.Entity<VolunteeringGoals>().ToTable("VolunteeringGoals", "CIProject");

            base.OnModelCreating(modelBuilder);
        }
    }
}

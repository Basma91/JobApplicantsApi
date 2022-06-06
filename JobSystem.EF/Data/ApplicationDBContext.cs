using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsSystem.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace JobSystem.EF.Data
{
   public class ApplicationDBContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JobApplicant>()
      .HasKey(bc => new { bc.JobId, bc.ApplicantId });
            builder.Entity<JobApplicant>()
                .HasOne(bc => bc.Applicant)
                .WithMany(b => b.JobApplicants)
                .HasForeignKey(bc => bc.ApplicantId);
            builder.Entity<JobApplicant>()
                .HasOne(bc => bc.Job)
                .WithMany(c => c.JobApplicants)
                .HasForeignKey(bc => bc.JobId);


            base.OnModelCreating(builder);
            //builder.HasDefaultSchema("security");
            builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");
        }

        public DbSet<Applicant> Applicants { set; get; }
        public DbSet<Job> Jobs { set; get; }
        public DbSet<JobApplicant> JobApplicants { get; set; }
    }
}

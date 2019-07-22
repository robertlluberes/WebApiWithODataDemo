using API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Community> Communities { get; set; }

        public DbSet<Technology> Technologies { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<CommunityMember> CommunityMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommunityMember>()
                .HasKey(cm => new { cm.CommunityId, cm.MemberId });

            modelBuilder.Entity<CommunityMember>()
                .HasOne(cm => cm.Community)
                .WithMany(c => c.CommunityMembers)
                .HasForeignKey(cm => cm.CommunityId);

            modelBuilder.Entity<CommunityMember>()
                .HasOne(cm => cm.Member)
                .WithMany(m => m.CommunityMembers)
                .HasForeignKey(cm => cm.MemberId);
        }
    }
}
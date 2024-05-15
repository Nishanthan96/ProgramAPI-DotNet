using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramDatabase.Models
{
    public class ProgramDbContext:DbContext
    {
        public DbSet<Application> ApplicationTemplate { get; set; }
        public DbSet<CustomQuestionTemplate> CustomQuestions { get; set; }

        public ProgramDbContext(DbContextOptions<ProgramDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultContainer("ApplicationTemplate");
            builder.HasDefaultContainer("CustomQuestion");

            builder.Entity<Application>()
                .ToContainer("ApplicationTemplate")
                .HasPartitionKey(c => c.Id)
                .HasNoDiscriminator();

            builder.Entity<CustomQuestionTemplate>()
            .ToContainer("CustomQuestion")
            .HasPartitionKey(c => c.Id)
            .HasNoDiscriminator();
        }
    }
}

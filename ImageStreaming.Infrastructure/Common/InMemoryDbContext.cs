using System;
using ImageStreaming.Domain.Entities;
using ImageStreaming.Shared.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace ImageStreaming.Infrastructure.Common
{
	public class InMemoryDbContext : BaseDbContext
    {
        public InMemoryDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ImagesDb");
        }

        public DbSet<Image> Images { get; set; }
    }
}


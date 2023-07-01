using System;
using Microsoft.EntityFrameworkCore;

namespace ImageStreaming.Shared.Persistence.Common
{
	public class BaseDbContext : DbContext
	{
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}


using BassClefStudio.LatinClub.Core.Events;
using BassClefStudio.LatinClub.Core.News;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BassClefStudio.LatinClub.Api.Data
{
    public class ClubContext : DbContext
    {
        public ClubContext(DbContextOptions<ClubContext> options) : base(options)
        { }

        public DbSet<ClubEvent> Events { get; set; }

        public DbSet<Article> Articles { get; set; }
    }
}

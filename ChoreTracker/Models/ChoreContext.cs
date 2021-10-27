using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChoreTracker.Models
{
    public class ChoreContext : DbContext
    {
        public ChoreContext(DbContextOptions<ChoreContext> options) : base(options)
        {
        }

        public DbSet<Chore> Chores { get; set; }
    }
}

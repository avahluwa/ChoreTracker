using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreTracker.Models
{
    public class OutsideChoresContext : DbContext
    {
        public OutsideChoresContext(DbContextOptions<OutsideChoresContext> options) : base(options)
        {
        }

        public DbSet<OutsideChores> OutsideChores { get; set; }
    }
}

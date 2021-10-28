using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreTracker.Models
{
    public class DTO
    {
        public List<OutsideChores> outsideChores { get; set; }
        public List<Chore> Chores { get; set; }
    }
}

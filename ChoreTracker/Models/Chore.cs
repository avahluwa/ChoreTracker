using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoreTracker.Models
{
    public class Chore
    {
        public long Id { get; set; }
        public string ChoreName { get; set; }
        public string nameOfAssigned { get; set; }
        public bool IsComplete { get; set; }
    }
}

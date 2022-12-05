using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221204
{
    internal class Calculator
    {
        
        public int CalculateResult(List<ElfAssignment> elfAssignments)
        {
            return elfAssignments.Where(e => e.AssignmentContains()).Count();
        }

        public int CalculateResult2(List<ElfAssignment> elfAssignments)
        {
            return elfAssignments.Where(e => e.AssignmentsOverlap()).Count();


        }
    }
}

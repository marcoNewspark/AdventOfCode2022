using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221204
{
    internal class ElfAssignment
    {
        public List<Assignment> ElfAssignments { get; } = new List<Assignment>();
        
        public ElfAssignment(int Elf1Start, int Elf1End, int Elf2Start, int Elf2End)
        {
            ElfAssignments.Add(new(Elf1Start, Elf1End));
            ElfAssignments.Add(new(Elf2Start, Elf2End));
        }

        public bool AssignmentContains()
        {
            return ElfAssignments[1].Contains(ElfAssignments[0]) || ElfAssignments[0].Contains(ElfAssignments[1]);
        }

        public bool AssignmentsOverlap()
        {
            return ElfAssignments[0].Overlaps(ElfAssignments[1]) || ElfAssignments[1].Overlaps(ElfAssignments[0]);
        }
    }
}

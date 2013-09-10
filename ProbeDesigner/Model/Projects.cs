using System.Collections.Generic;
using System.Linq;

namespace ProbeDesigner.Model
{
    public class Projects
    {
        public Projects(IEnumerable<Project> probelist)
        {
            AllProjects = probelist.ToList();
        }

        public List<Project> AllProjects { get; private set; }
    }
}
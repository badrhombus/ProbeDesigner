using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbeDesigner.Model
{
    public class GroupedProbe
    {
        public string Name { get; set; }
        public IEnumerable<Probe> Probes { get; set; }
    }
}

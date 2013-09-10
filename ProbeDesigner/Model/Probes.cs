using System.Collections.Generic;

namespace ProbeDesigner.Model
{
    public class Probes
    {
        public Probes(IEnumerable<Probe> probelist) {AllProbes = probelist;}
        public IEnumerable<Probe> AllProbes { get; private set; }
    }
}
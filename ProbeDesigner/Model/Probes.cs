using System.Collections.Generic;

namespace RevolutionProbe.Model
{
    public class Probes
    {
        public Probes(IEnumerable<Probe> probelist) {AllProbes = probelist;}
        public IEnumerable<Probe> AllProbes { get; private set; }
    }
}
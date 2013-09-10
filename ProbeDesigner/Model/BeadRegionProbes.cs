using System.Collections.Generic;

namespace ProbeDesigner.Model
{
    public class BeadRegionProbes
    {
        public int Bead { get; set; }
        public ICollection<Probe> Probes { get; set; }
    }
}
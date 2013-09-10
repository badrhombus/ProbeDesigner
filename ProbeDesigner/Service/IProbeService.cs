using System;
using ProbeDesigner.Model;
using RevolutionProbe.Model;

namespace ProbeDesigner.Service
{
    public interface IProbeService
    {
        void ImportProbes(Action<Probes, Exception> callback);
        void SaveProbes(Action<Probes, Exception> callback);
        void ComputeSequences(Probe probe, Action<ProbeSegments, Exception> callback);
        void SaveAllProbeSequences(Probes probes);
    }
}
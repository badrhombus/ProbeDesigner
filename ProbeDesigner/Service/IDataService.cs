using System;
using ProbeDesigner.Model;

namespace ProbeDesigner.Service
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        void GetImgtSequenceData(Action<ImgtSequences, Exception> callback);
    }
}

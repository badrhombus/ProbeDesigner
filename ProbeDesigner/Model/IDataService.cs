using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProbeDesigner.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        void GetImgtSequenceData(Action<ImgtSequences, Exception> callback);
    }
}

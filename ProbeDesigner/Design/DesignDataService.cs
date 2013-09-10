using System;
using ProbeDesigner.Model;
using ProbeDesigner.Service;

namespace ProbeDesigner.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }


        public void GetImgtSequenceData(Action<ImgtSequences, Exception> callback)
        {
            var item = new ImgtSequences("Welcome to Probe Designer Light [design]");
            callback(item, null);
        }
    }
}
using System;

namespace ProbeDesigner.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }


        public void GetImgtSequenceData(Action<ImgtSequences, Exception> callback)
        {
            var item = new ImgtSequences("Welcome to Probe Designer Light");
            callback(item, null);
        }
    }
}
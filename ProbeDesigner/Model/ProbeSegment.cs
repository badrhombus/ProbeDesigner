using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RevolutionProbe.Model
{
    public class ProbeSegment
    {
        private string _segment;
        private bool _isComplement;
        private int _gc;
        private int _tm;

        public string Segment
        {
            get { return _segment; }
            set { _segment = value; }
        }

        public ProbeSegment(string segment, bool isComplement=false)
        {
            _segment = segment;
            _isComplement = isComplement;
        }

        public bool IsComplement
        {
            get { return _isComplement; }
            set { _isComplement = value; }
        }

        public int GC
        {
            get { return _gc; }
        }

        public int TM
        {
            get { return _tm; }
        }
    }
}

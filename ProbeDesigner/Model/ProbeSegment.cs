namespace ProbeDesigner.Model
{
    public class ProbeSegment
    {
        private int _gc;
        private bool _isBridge;
        private bool _isComplement;
        private string _segment;
        private int _tm;

        public ProbeSegment(string segment, bool isComplement = false)
        {
            _segment = segment;
            _isComplement = isComplement;
        }

        public int GC
        {
            get { return _gc; }
        }

        public bool IsBridge
        {
            get { return _isBridge; }
            set { _isBridge = value; }
        }

        public bool IsComplement
        {
            get { return _isComplement; }
            set { _isComplement = value; }
        }

        public string Segment
        {
            get { return _segment; }
            set { _segment = value; }
        }

        public int TM
        {
            get { return _tm; }
        }
    }
}
using System;
using System.Linq;
using System.Text.RegularExpressions;
using RevolutionProbe.Common;

namespace RevolutionProbe.Model
{
    [Serializable]
    public class Probe
    {
        private static readonly Regex _reProbe = new Regex(
            "(?<alpha>\\D+)(?<digits>\\d+)(?<suffix1>\\D+)*($|(-((?<rev>\\d+)(?<suffix2>\\D+)*)*)+)",
            RegexOptions.CultureInvariant | RegexOptions.Compiled);

        private string _group;
        private bool? _isReverseComplement;
        private bool? _isGap;
        private bool? _isTandem;
        private string _name;
        private int _revision;
        private string _sequence;
        private string _suffix;
        private ProbeSegments _segments;

        public Probe(string name, string sequence = "")
        {
            _name = name;
            _sequence = sequence;
            _segments = new ProbeSegments();
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string Sequence
        {
            get { return _sequence; }
            set { _sequence = value; }
        }

        public string Group
        {
            get
            {
                if (_group != null) return _group;
                if (suffix == null) ParseProbeName();
                return _group;
            }
            set { _group = value; }
        }

        public bool IsGap
        {
            get
            {
                if (_isGap != null) return (bool) _isGap;
                if (suffix == null) return false;
                return (bool) (_isGap = suffix.Contains("G"));
            }
            set { _isGap = value; }
        }

        public bool IsTandem
        {
            get
            {
                if (_isTandem != null) return (bool) _isTandem;

                if (suffix == null) return false;
                return (bool) (_isTandem = suffix.Contains("T"));
            }
            set { _isTandem = value; }
        }

        public bool IsReverseComplement
        {
            get
            {
                if (_isReverseComplement != null) return (bool) _isReverseComplement;
                if (suffix == null) return false;
                return (bool) (_isReverseComplement = suffix.Contains("C"));
            }
            set { _isReverseComplement = value; }
        }

        private string suffix
        {
            get
            {
                if (_suffix != null) return _suffix;
                ParseProbeName();
                return _suffix;
            }
            set { _suffix = value; }
        }

        public int Revision
        {
            get { return _revision; }
            set { _revision = value; }
        }

        public ProbeSegments Segments
        {
            get
            {
                if(_segments.Count>0) return _segments;
                if(_sequence.Length>0) ParseSegments();
                return _segments;
            }
            set { _segments = value; }
        }

        private void ParseSegments()
        {
            var seq = _sequence.CorePattern();
            _segments.Add(new ProbeSegment(seq));
        }

        public override string ToString()
        {
            return Name;
        }

        private void ParseProbeName()
        {
            Match match = _reProbe.Match(_name);
            string alpha = match.Groups["alpha"].Value;
            string suffix = string.Empty;
            if (alpha.Length > 1 && alpha.Contains('T')) suffix = "T";
            Group suffix1 = match.Groups["suffix1"];
            Group suffix2 = match.Groups["suffix2"];
            _suffix = suffix1.Value + suffix2.Value + suffix;
            _group = match.Groups["alpha"].Value + match.Groups["digits"].Value;
            int ver;
            int.TryParse(match.Groups["rev"].Value, out ver);
            _revision = ver;
        }

//"(?<alpha>\\D+)(?<digits>\\d+)(?<suffix1>\\D+)*($|(-((?<rev>\\d+)(?<suffix2>\\D+)*)*)+)"





    }
}
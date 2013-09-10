using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProbeDesigner.Model;
using RevolutionProbe.Model;

namespace RevolutionProbe.Common
{
    public class ProbeComparer : IComparer<Probe>
    {
        private readonly Regex _reProbe = new Regex(
            "(?<alpha>\\D+)(?<digits>\\d+)(?<suffix1>\\D+)*($|(-((?<rev>\\d+)(?<suffix2>\\D+)*)*)+)",
            RegexOptions.CultureInvariant | RegexOptions.Compiled);

        public int Compare(Probe x, Probe y)
        {
            Match matchX = _reProbe.Match(x.Name); // very slow
            Match matchY = _reProbe.Match(y.Name);
            int i, j;
            int result = String.CompareOrdinal(matchX.Groups["alpha"].Value, matchY.Groups["alpha"].Value);
            if (result != 0) return result;
            int.TryParse(matchX.Groups["digits"].Value, out i);
            int.TryParse(matchY.Groups["digits"].Value, out j);
            result = i - j;
            if (result != 0) return result;
            int.TryParse(matchX.Groups["rev"].Value, out i);
            int.TryParse(matchY.Groups["rev"].Value, out j);
            result = i - j;
            if (result != 0) return result;
            result = String.CompareOrdinal(matchX.Groups["suffix2"].Value, matchY.Groups["suffix2"].Value);
            return result;
        }

    }
}
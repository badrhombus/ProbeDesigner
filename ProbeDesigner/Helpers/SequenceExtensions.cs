using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RevolutionProbe.Common
{
    public static class SequenceExtensions
    {   
        //Probe Sequence = "/5AmMC6/TTTTTTTTTTTTTTTTTTTTgggAAACggAggTgTAgAAATACCTCATg"

        private static readonly Regex ReCore = new Regex(@"(t{5,})*(?<probe>[gatc]{5,})", RegexOptions.IgnoreCase);

        public static string CorePattern(this string probe)
        {
            Match match = ReCore.Match(probe);
            if (!match.Success) return string.Empty;
            return match.Groups["probe"].Value;
        }

        public static string ReverseComplement(this string sequence)
        {
            var trans = new StringBuilder(String.Empty);
            for (int i = sequence.Length - 1; i >= 0; i--)
            {
                switch (sequence[i])
                {
                    case 'a':
                    case 'A':
                        trans.Append('t');
                        break;
                    case 't':
                    case 'T':
                        trans.Append('a');
                        break;
                    case 'c':
                    case 'C':
                        trans.Append('g');
                        break;
                    case 'g':
                    case 'G':
                        trans.Append('c');
                        break;
                    case 'n':
                    case 'N':
                        trans.Append('n');
                        break;
                    default:
                        trans.Append(sequence[i]);
                        break;
                }
            }
            return trans.ToString();
        }

        public static string SquishGapFormat(this string sequence)
        {
            if (sequence.Length > 15)
            {
                var sb = new StringBuilder(sequence);
                sb = sb.Remove(5, sb.Length - 10).Insert(5, string.Format("<--{0}-->", sequence.Length));
                sequence = sb.ToString();
            }
            return sequence;
        }

        public static string TrimSequenceEnds(this string sequence)
        {
            if (sequence.Length > 2)
                sequence = sequence.Substring(1, sequence.Length - 2);
            return sequence;
        }
    }
}
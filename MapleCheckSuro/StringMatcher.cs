using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCheckSuro
{
    public class StringMatcher
    {
        public static string FindClosestMatch(string[] existingTexts, string originalText)
        {
            string decomposedOriginal = HangulUtils.DecomposeToString(originalText);
            string closestMatch = null;
            int minDistance = int.MaxValue;

            foreach (string text in existingTexts)
            {
                string decomposedText = HangulUtils.DecomposeToString(text);
                int distance = LevenshteinDistance.Compute(decomposedText, decomposedOriginal);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestMatch = text;
                }
            }

            return closestMatch;
        }
    }
}

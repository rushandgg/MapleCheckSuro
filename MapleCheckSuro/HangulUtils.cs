using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCheckSuro
{
    public class HangulUtils
    {
        private static readonly char[] InitialConsonants =
    {
        'ㄱ', 'ㄲ', 'ㄴ', 'ㄷ', 'ㄸ', 'ㄹ', 'ㅁ', 'ㅂ', 'ㅃ', 'ㅅ', 'ㅆ', 'ㅇ', 'ㅈ', 'ㅉ', 'ㅊ', 'ㅋ', 'ㅌ', 'ㅍ', 'ㅎ'
    };

        private static readonly char[] MedialVowels =
        {
        'ㅏ', 'ㅐ', 'ㅑ', 'ㅒ', 'ㅓ', 'ㅔ', 'ㅕ', 'ㅖ', 'ㅗ', 'ㅘ', 'ㅙ', 'ㅚ', 'ㅛ', 'ㅜ', 'ㅝ', 'ㅞ', 'ㅟ', 'ㅠ', 'ㅡ', 'ㅢ', 'ㅣ'
    };

        private static readonly char[] FinalConsonants =
        {
        '\0', 'ㄱ', 'ㄲ', 'ㄳ', 'ㄴ', 'ㄵ', 'ㄶ', 'ㄷ', 'ㄹ', 'ㄺ', 'ㄻ', 'ㄼ', 'ㄽ', 'ㄾ', 'ㄿ', 'ㅀ', 'ㅁ', 'ㅂ', 'ㅄ', 'ㅅ', 'ㅆ', 'ㅇ', 'ㅈ', 'ㅊ', 'ㅋ', 'ㅌ', 'ㅍ', 'ㅎ'
    };

        public static (char initial, char medial, char final) Decompose(char ch)
        {
            if (ch >= 0xAC00 && ch <= 0xD7A3)
            {
                int unicodeIndex = ch - 0xAC00;

                int initialConsonantIndex = unicodeIndex / (21 * 28);
                int medialVowelIndex = (unicodeIndex % (21 * 28)) / 28;
                int finalConsonantIndex = unicodeIndex % 28;

                return (InitialConsonants[initialConsonantIndex], MedialVowels[medialVowelIndex], FinalConsonants[finalConsonantIndex]);
            }

            return (ch, '\0', '\0'); // 한글이 아니면 그대로 반환
        }

        public static string DecomposeToString(string input)
        {
            return string.Concat(input.Select(c =>
            {
                var (initial, medial, final) = Decompose(c);
                return $"{initial}{medial}{final}";
            }));
        }
    }
}

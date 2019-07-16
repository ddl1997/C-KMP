using System.Linq;

namespace KMP
{
    class KMP_Impl
    {
        public int[] _next { get; }
        string _mod;

        public KMP_Impl(string mod)
        {
            _next = new int[mod.Length];
            _mod = mod;
            for (int i = 0; i < _next.Length; i++)
            {
                if (i == 0)
                    _next[i] = -1;
                else
                {
                    _next[i] = PrePostMaxLength(mod.Substring(i));
                }
            }
        }

        public int GetIndex(string str)
        {
            int matchIndex = -1;
            int index = 0;
            int modIndex = 0;

            while (index <= str.Length - _mod.Length)
            {
                for (; modIndex < _mod.Length; modIndex++, index++)
                {
                    if (!Equals(_mod.ElementAt(modIndex), str.ElementAt(index)))
                    {
                        break;
                    }
                }
                if (modIndex == _mod.Length)
                {
                    matchIndex = index - _mod.Length;
                    break;
                }
                else if (modIndex == 0)
                {
                    //modIndex = 0;
                    index++;
                }
                else
                {
                    modIndex = _next[modIndex];
                }
            }

            return matchIndex;
        }

        public static int PrePostMaxLength(string str)
        {
            int max_length = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (string.Equals(str.Substring(0, i), str.Substring(str.Length - i, i)))
                    max_length = i;
            }
            return max_length;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class WordsLadderLength
    {
        private static Dictionary<string, int> _dict = new Dictionary<string, int>();
        private static Dictionary<string, int> _resultSet = new Dictionary<string, int>();
        private static int _result = int.MaxValue;
        private static int _wordLength = 0;
        private static List<string> _bestResult = new List<string>();
        private static List<string> _intermideateResult = new List<string>();


        public static List<string> _tempResult = new List<string>();
        public static List<List<string>>  FindWordLadder(string start, string end)
        {

        }


        public static void TestGetLadderLength(string start, string end)
        {
            _wordLength = start.Length;
            _dict.Add("aaa", 0);
            _dict.Add("bbc", 0);
            _dict.Add("cbc", 0);
            _dict.Add("bac", 0);
            _dict.Add("cbd", 0);
            _dict.Add("cog", 0);
            _dict.Add("hog", 0);

            foreach (KeyValuePair<string, int> p in _dict)
            {
                _resultSet.Add(p.Key, int.MaxValue);
            }

            _resultSet.Remove(start);
            _resultSet.Add(start, 1);
            _intermideateResult.Add(start);
            _bestResult.Add(start);
            SearchLadderLength(start, end);

            Console.WriteLine("The best result is " );
            foreach (string word in _bestResult)
            {
                Console.WriteLine(word);
            }

        }

        private static void SearchLadderLength(string start, string end)
        {
            StringBuilder sTemp ;
            int tempOutValue = 0;
            for (int i = 0; i < _wordLength; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    sTemp = new StringBuilder(start);
                    sTemp[i] = (char) ('a' + j);
                    string s = sTemp.ToString();

                    if (s.CompareTo(start) != 0 && _dict.TryGetValue(s, out tempOutValue))
                    {
                        int a, b;
                        _resultSet.TryGetValue(s, out a);
                        _resultSet.TryGetValue(start, out b);
                        if (a > b + 1)
                        {
                            _resultSet.Remove(s);
                            _resultSet.Add(s, b + 1);
                            _dict.Remove(start);
                            _intermideateResult.Add(s);

                            if (s.CompareTo(end) != 0)
                            {
                                SearchLadderLength(s, end);
                            }
                            else
                            {
                                if (_result > b + 1)
                                {
                                    _result = b + 1;
                                    _bestResult = _intermideateResult.ToList<string>();
                                }

                                Console.WriteLine("Lenth: {0}", b + 1);
                                foreach (string word in _intermideateResult)
                                {
                                    Console.WriteLine(word);
                                }
                            }

                            _dict.Add(start, 0);
                            _intermideateResult.Remove(s);
                        }
                    }
                }
            }
        }
    }
}

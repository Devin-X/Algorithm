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

        public static void GetLadderLength(string start, string end)
        {
            _wordLength = start.Length;
            _dict.Add("hot", 0);
            _dict.Add("dot", 0);
            _dict.Add("dog", 0);
            _dict.Add("lot", 0);
            _dict.Add("log", 0);
            _dict.Add("cog", 0);

            foreach (KeyValuePair<string, int> p in _dict)
            {
                _resultSet.Add(p.Key, int.MaxValue);
            }

            _resultSet.Remove(start);
            _resultSet.Add(start, 1);
            _bestResult.Add(start);
            SearchLadderLength(start, end);

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
                            _bestResult.Add(s);

                            if (s.CompareTo(end) != 0)
                            {
                                SearchLadderLength(s, end);
                            }
                            else
                            {
                                if (_result > b + 1)
                                {
                                    _result = b + 1;
                                }

                                Console.WriteLine("Lenth: {0}", b + 1);
                                foreach (string word in _bestResult)
                                {
                                    Console.WriteLine(word);
                                }

                                //_bestResult.Remove(s);
                                //_dict.Add(start, 0);
                                //return;
                            }

                            _dict.Add(start, 0);
                            _bestResult.Remove(s);
                        }
                    }
                }
            }
        }
    }
}

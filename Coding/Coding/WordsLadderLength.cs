﻿using System;
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


        public static HashSet<string> _dictionary = new HashSet<string>();
        public static Dictionary<string, List<string>> _allPathsDict = new Dictionary<string, List<string>>();
        public static List<string> _tempResult = new List<string>();
        public static List<string> _levelNodes = new List<string>();
        public static List<List<string>> _levelList = new List<List<string>>();
        public static int _minLenCache = 0;
        public static int _minLenghBFS = int.MaxValue;
        public static int index = 0;
        public static int FindWordLadder(string start, string end)
        {
            _levelNodes.Remove(start);
            List<string> toRemove = _levelList[0];
            _levelList.Remove(toRemove);

            for (int i = 0; i < start.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    char[] a = start.ToCharArray();
                    a[i] = (char)('a' + j);
                    string temp = new string(a);
                    if (_dictionary.Contains(temp))
                    {
                        List<string> ret;
                        if (_levelList.Count > 0)
                        {
                            ret = new List<string>(_levelList[index]);
                        }
                        else
                        {
                            ret = new List<string>();
                            ret.Add(start);
                        }

                        ret.Add(temp);
                        _levelList.Add(ret);
                        _levelNodes.Add(temp);
                        if (temp.CompareTo(end) == 0)
                        {
                            if (_minLenghBFS < _minLenCache)
                                return _minLenghBFS;
                            _minLenghBFS = _minLenCache;
                        }
                    }
                }
            }

            _dictionary.Remove(start);
            if (_levelNodes.Count > 0)
            {
                string s = _levelNodes[0];
                _dictionary.Remove(s);
                _minLenCache++;
                index++;
                FindWordLadder(s, end);
                _dictionary.Add(s);
                _dictionary.Add(start);
            }

            return _minLenghBFS;
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

            Console.WriteLine("The best result is ");
            foreach (string word in _bestResult)
            {
                Console.WriteLine(word);
            }

            _levelNodes.Add(start);
            _levelList.Add(new List<string>());
            _dictionary.Add("aaa");
            _dictionary.Add("bbc");
            _dictionary.Add("cbc");
            _dictionary.Add("bac");
            _dictionary.Add("cbd");
            _dictionary.Add("cog");
            _dictionary.Add("hog");
            Console.WriteLine(FindWordLadder(start, end));
        }

        private static void SearchLadderLength(string start, string end)
        {
            StringBuilder sTemp;
            int tempOutValue = 0;
            for (int i = 0; i < _wordLength; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    sTemp = new StringBuilder(start);
                    sTemp[i] = (char)('a' + j);
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

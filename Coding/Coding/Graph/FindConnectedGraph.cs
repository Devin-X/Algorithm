using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class FindConnectedGraph
    {
        /// <summary>
        /// O N solution for the 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<List<char>> GetSets(List<KeyValuePair<char, char>> list)
        {
            Dictionary<char, HashSet<char>> cache = new Dictionary<char, HashSet<char>>();
            HashSet<string> set = new HashSet<string>();
            List<List<char>> ret = new List<List<char>>();

            foreach (KeyValuePair<char, char> p in list)
            {
                HashSet<char> subGraph = new HashSet<char>();
                subGraph.Add(p.Key);
                subGraph.Add(p.Value);

                if (cache.ContainsKey(p.Key) && !cache.ContainsKey(p.Value))
                {
                    cache[p.Key].Add(p.Value);
                }
                else if (cache.ContainsKey(p.Value) && !cache.ContainsKey(p.Key))
                {
                    cache[p.Value].Add(p.Key);
                }
                else if (cache.ContainsKey(p.Key) && cache.ContainsKey(p.Value))
                {
                    cache[p.Key].UnionWith(cache[p.Value]);
                    cache[p.Value].Clear();
                }
                else
                {
                    cache.Add(p.Key, subGraph);
                    cache.Add(p.Value, subGraph);
                }
            }

            foreach (KeyValuePair<char, HashSet<char>> hs in cache)
            {
                string s = new string(hs.Value.ToArray());
                if (!set.Contains(s) && hs.Value.Count > 0)
                {
                    ret.Add(hs.Value.ToList());
                    set.Add(s);
                }
            }

            return ret;
        }

        public static List<HashSet<char>> GetSetsONSquare(List<KeyValuePair<char, char>> list)
        {
            List<HashSet<char>> ret = new List<HashSet<char>>();
            List<HashSet<char>> next = new List<HashSet<char>>();

            foreach(KeyValuePair<char, char> p in list)
            {
                int foundIndex = -1;
                next = new List<HashSet<char>>();
                HashSet<char> subGraph = new HashSet<char>();
                subGraph.Add(p.Key);
                subGraph.Add(p.Value);
                 ret.Add(subGraph);
                for(int i = 0; i < ret.Count; i++)
                {
                    if(ret[i].Contains(p.Key) || ret[i].Contains(p.Value))
                    {
                        if (foundIndex == -1)
                            foundIndex = i;
                        else
                        {
                            ret[foundIndex].UnionWith(ret[i]);
                        }
                    }
                    else
                    {
                        next.Add(ret[i]);
                    }
                }
                
                if(foundIndex != -1)
                {
                    next.Add(ret[foundIndex]);
                }

                ret = next;
            }

            return ret;
        }

        public static void Test()
        {
            List<KeyValuePair<char, char>> list = new List<KeyValuePair<char, char>>();
            list.Add(new KeyValuePair<char, char>('A', 'B'));
            list.Add(new KeyValuePair<char, char>('C', 'D'));
            list.Add(new KeyValuePair<char, char>('E', 'F'));
            list.Add(new KeyValuePair<char, char>('G', 'H'));
            list.Add(new KeyValuePair<char, char>('A', 'D'));
            list.Add(new KeyValuePair<char, char>('F', 'G'));
            list.Add(new KeyValuePair<char, char>('A', 'I'));

            List<List<char>> ret = GetSets(list);

            foreach(List<char> lc in ret)
            {
                Console.WriteLine(string.Join(",", lc));
            }
        }
    }
}

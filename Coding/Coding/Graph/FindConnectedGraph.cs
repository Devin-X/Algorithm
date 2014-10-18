using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class FindConnectedGraph
    {

        public static List<HashSet<char>> GetSets(List<KeyValuePair<char, char>> list)
        {
            HashSet<string> set = new HashSet<string>();
            HashSet<char> temp = new HashSet<char>();
            List<HashSet<char>> ret = new List<HashSet<char>>();
            foreach (KeyValuePair<char, char> p in list)
            {
                string s = string.Format("{0}{1}", p.Key, p.Value);
                set.Add(s);
                HashSet<char> subGraph = new HashSet<char>();
                subGraph.Add(p.Key);
                subGraph.Add(p.Value);
                ret.Add(subGraph);
            }

            for (int i = 0; i < list.Count; i++)
            {
                KeyValuePair<char, char> p = list[i];
                bool isConnected = false;
                string a = string.Format("{0}{1}", p.Key, p.Value);
                if(!set.Contains(a))
                {
                    continue;
                }

                temp.Add(p.Key);
                temp.Add(p.Value);

                for (int j = i + 1; j < list.Count; j++)
                {
                    KeyValuePair<char, char> pp = list[j];
                    string s1 = string.Format("{0}{1}", p.Key, pp.Key);
                    string s2 = string.Format("{0}{1}", p.Key, pp.Value);
                    string s3 = string.Format("{0}{1}", p.Value, pp.Key);
                    string s4 = string.Format("{0}{1}", p.Value, pp.Value);
                    string b = string.Format("{0}{1}", pp.Value, pp.Value);

                    if (set.Contains(s1) || set.Contains(s2) || set.Contains(s3) || set.Contains(s4) ||
                        set.Contains(s1.Reverse()) || set.Contains(s2.Reverse()) || set.Contains(s3.Reverse()) || set.Contains(s4.Reverse())
                        )
                    {
                        temp.Add(pp.Key);
                        temp.Add(pp.Value);
                        set.Remove(s1);
                        set.Remove(s2);
                        set.Remove(s3);
                        set.Remove(s4);
                        set.Remove(s1.Reverse().ToString());
                        set.Remove(s1.Reverse().ToString());
                        set.Remove(s1.Reverse().ToString());
                        set.Remove(s1.Reverse().ToString());
                        set.Remove(b);
                        isConnected = true;
                    }
                }

                if(isConnected)
                {
                    set.Remove(a);
                    for(int j = i; j < list.Count; j++)
                        if(temp.Contains(list[j].Key) || temp.Contains(list[j].Value))
                        {
                            set.Remove(string.Format("{0}{1}", list[j].Key, list[j].Value));
                        }
                }

                ret.Add(temp.ToList());
                temp.Clear();
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
            list.Add(new KeyValuePair<char, char>('A', 'F'));

            List<List<char>> ret = GetSets(list);

            foreach(List<char> lc in ret)
            {
                Console.WriteLine(lc.ToArray());
            }
        }
    }
}

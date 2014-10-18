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

            List<HashSet<char>> ret = GetSets(list);

            foreach(HashSet<char> lc in ret)
            {
                Console.WriteLine(lc.ToArray());
            }
        }
    }
}

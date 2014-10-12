using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Vertice
    {
        public int data;
        public List<Vertice> neighbors;

        public Vertice(int d)
        {
            data = d;
            neighbors = new List<Vertice>();
        }
    }

    class CloneGraphI
    {
        /// <summary>
        /// Using the data in the vertice to be the key in this version
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Vertice CloneGraph(Vertice node)
        {
            Queue<Vertice> q = new Queue<Vertice>();
            q.Enqueue(node);
            Vertice ret = new Vertice(node.data);
            Queue<Vertice> qShadow = new Queue<Vertice>();
            qShadow.Enqueue(ret);
            Dictionary<int, Vertice> map = new Dictionary<int, Vertice>();
            map.Add(ret.data, ret);
            while(q.Any())
            {
                Vertice current = q.Dequeue();
                Vertice shadow = qShadow.Dequeue();

                foreach(Vertice v in current.neighbors)
                {
                    if (!map.ContainsKey(v.data))
                    {
                        Vertice clone = new Vertice(v.data);
                        shadow.neighbors.Add(clone);
                        q.Enqueue(v);
                        qShadow.Enqueue(clone);
                        map.Add(clone.data, clone);
                    }
                    else
                    {
                        Vertice clone;
                        if (map.TryGetValue(v.data, out clone))
                        {
                            shadow.neighbors.Add(clone);
                        }
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// This version, I use the vertice as the key in the dictionary. Not the data of the vertice. 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static Vertice CloneGraphV2(Vertice node)
        {
            Queue<Vertice> q = new Queue<Vertice>();
            q.Enqueue(node);
            Vertice ret = new Vertice(node.data);
            Queue<Vertice> qShadow = new Queue<Vertice>();
            qShadow.Enqueue(ret);
            Dictionary<Vertice, Vertice> map = new Dictionary<Vertice, Vertice>();
            map.Add(node, ret);
            while(q.Any())
            {
                Vertice current = q.Dequeue();
                Vertice shadow = qShadow.Dequeue();
                foreach(Vertice v in current.neighbors)
                {
                    if(!map.ContainsKey(v))
                    {
                        Vertice clone = new Vertice(v.data);
                        shadow.neighbors.Add(clone);
                        q.Enqueue(v);
                        qShadow.Enqueue(clone);
                        map.Add(v, clone);
                    }
                    else
                    {
                        Vertice clone;
                        if(map.TryGetValue(v, out clone))
                        {
                            shadow.neighbors.Add(clone);
                        }
                        
                    }
                }
            }

            return ret;
        }

        public static void Test()
        {
            Vertice node1 = new Vertice(1);
            Vertice node2 = new Vertice(2);
            Vertice node3 = new Vertice(3);
            Vertice node4 = new Vertice(4);
            Vertice node5 = new Vertice(5);
            node1.neighbors.Add(node2);
            node1.neighbors.Add(node3);
            node3.neighbors.Add(node4);
            node3.neighbors.Add(node5);
            node4.neighbors.Add(node5);
            node4.neighbors.Add(node1);

            //Vertice ret = CloneGraph(node1);
            Vertice ret = CloneGraphV2(node1);

            Queue<Vertice> q = new Queue<Vertice>();
            q.Enqueue(ret);
            HashSet<int> visited = new HashSet<int>();
            while(q.Any())
            {
                Vertice c = q.Dequeue();
                visited.Add(c.data);
                foreach(Vertice v in c.neighbors)
                {
                    Console.WriteLine("{0} --- > {1}", c.data, v.data);
                    if (!visited.Contains(v.data))
                    {
                        q.Enqueue(v);
                    }
                }
            }
        }
    }
}

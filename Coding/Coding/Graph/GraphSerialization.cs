using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Graph
{

    /**
     * Definition for undirected graph.
     * public class UndirectedGraphNode {
     *     public int label;
     *     public IList<UndirectedGraphNode> neighbors;
     *     public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
     * };
     */

    public class UndirectedGraphNode
    {
        public int label;
        public IList<UndirectedGraphNode> neighbors;
        public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }

        public class Solution
        {
            public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
            {

            }
        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class WordsLadderLength
    {
        public static List<List<string>> _levelList = new List<List<string>>();
        public static List<List<string>> _finalList = new List<List<string>>();

        public static Queue<string> _queue = new Queue<string>();
        public static Queue<string> _next = new Queue<string>();
        public static int _minLenghBFS = 1;
        public static int index = 0;
        public static List<List<string>> FindWordLadder(string start, string end, HashSet<string> _dictionary)
        {
            _queue.Enqueue(start);
            HashSet<string> visited = new HashSet<string>();
            List<string> startList = new List<string>();
            startList.Add(start);
            _levelList.Add(startList);
            while (_queue.Any())
            {
                string s = _queue.Dequeue();
                visited.Add(s);

                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        char[] a = s.ToCharArray();
                        a[i] = (char)('a' + j);
                        string temp = new string(a);
                        if (_dictionary.Contains(temp) && !visited.Contains(temp))
                        {
                            List<string> ret;
                            ret = new List<string>(_levelList[index]);

                            ret.Add(temp);
                            _levelList.Add(ret);
                            _next.Enqueue(temp);
                            if (temp.CompareTo(end) == 0)
                            {
                                visited.Remove(end);
                                _finalList.Add(ret);
                                continue;
                            }
                        }
                    }
                }

                if (!_queue.Any() && _next.Any())
                {
                    _queue = _next;
                    _minLenghBFS++;
                    HashSet<string> visitedNext = new HashSet<string>(_next.ToArray());
                    //Console.WriteLine(string.Join("-", _next));
                    _next = new Queue<string>();
                    visited.UnionWith(visitedNext);
                }

                index++;
            }

            return _finalList;
        }


        public static void TestGetLadderLength()
        {
            //_treeStack.Add("abc");
            //_treeStack.Add("||");
            //_levelList.Add(new List<string>());
            HashSet<string> _dictionary = InitData(); // new HashSet<string>();
            //_dictionary.Add("aaa");
            //_dictionary.Add("bbc");
            //_dictionary.Add("cbc");
            //_dictionary.Add("bac");
            //_dictionary.Add("cbd");
            //_dictionary.Add("cog");
            //_dictionary.Add("hog");
            Console.WriteLine(FindWordLadder("nape", "mild", _dictionary));
            //Console.WriteLine(FindWordLadder("hit", "cog", _dictionary));

            foreach(List<string>  ls in _finalList)
            {
                Console.WriteLine(string.Join("-->", ls));
            }
        }


        public static HashSet<string> InitData()
        {

            string[] data = {"dose", "ends", "dine", "jars", "prow", "soap", "guns", "hops", "cray", "hove",
                "ella", "hour", "lens", "jive", "wiry", "earl", "mara", "part", "flue", "putt",
               "rory", "bull", "york", "ruts", "lily", "vamp", "bask", "peer", "boat", "dens",
                "lyre", "jets", "wide", "rile", "boos", "down", "path", "onyx", "mows", "toke",
                "soto", "dork", "nape", "mans", "loin", "jots", "male", "sits", "minn", "sale",
                "pets", "hugo", "woke", "suds", "rugs", "vole", "warp", "mite", "pews", "lips",
                "pals", "nigh", "sulk", "vice", "clod", "iowa", "gibe", "shad", "carl", "huns",
                "coot", "sera", "mils", "rose", "orly", "ford", "void", "time", "eloy", "risk",
                "veep", "reps", "dolt", "hens", "tray", "melt", "rung", "rich", "saga", "lust",
                "yews", "rode", "many", "cods", "rape", "last", "tile", "nosy", "take", "nope",
                "toni", "bank", "jock", "jody", "diss", "nips", "bake", "lima", "wore", "kins",
                "cult", "hart", "wuss", "tale", "sing", "lake", "bogy", "wigs", "kari", "magi",
                "bass", "pent", "tost", "fops", "bags", "duns", "will", "tart", "drug", "gale",
                "mold", "disk", "spay", "hows", "naps", "puss", "gina", "kara", "zorn", "boll",
                "cams", "boas", "rave", "sets", "lego", "hays", "judy", "chap", "live", "bahs",
                "ohio", "nibs", "cuts", "pups", "data", "kate", "rump", "hews", "mary", "stow",
                "fang", "bolt", "rues", "mesh", "mice", "rise", "rant", "dune", "jell", "laws",
                "jove", "bode", "sung", "nils", "vila", "mode", "hued", "cell", "fies", "swat",
                "wags", "nate", "wist", "honk", "goth", "told", "oise", "wail", "tels", "sore",
                "hunk", "mate", "luke", "tore", "bond", "bast", "vows", "ripe", "fond", "benz",
                "firs", "zeds", "wary", "baas", "wins", "pair", "tags", "cost", "woes", "buns",
                "lend", "bops", "code", "eddy", "siva", "oops", "toed", "bale", "hutu", "jolt",
                "rife", "darn", "tape", "bold", "cope", "cake", "wisp", "vats", "wave", "hems",
                "bill", "cord", "pert", "type", "kroc", "ucla", "albs", "yoko", "silt", "pock",
                "drub", "puny", "fads", "mull", "pray", "mole", "talc", "east", "slay", "jamb",
                "mill", "dung", "jack", "lynx", "nome", "leos", "lade", "sana", "tike", "cali",
                "toge", "pled", "mile", "mass", "leon", "sloe", "lube", "kans", "cory", "burs",
                "race", "toss", "mild", "tops", "maze", "city", "sadr", "bays", "poet", "volt",
                "laze", "gold", "zuni", "shea", "gags", "fist", "ping", "pope", "cora", "yaks",
                "cosy", "foci", "plan", "colo", "hume", "yowl", "craw", "pied", "toga", "lobs",
                "love", "lode", "duds", "bled", "juts", "gabs", "fink", "rock", "pant", "wipe",
                "pele", "suez", "nina", "ring", "okra", "warm", "lyle", "gape", "bead", "lead",
                "jane", "oink", "ware", "zibo", "inns", "mope", "hang", "made", "fobs", "gamy",
                "fort", "peak", "gill", "dino", "dina", "tier", "hot","dot","dog","lot","log", "cog"};

            HashSet<string> _dictionary = new HashSet<string>(data);
            return _dictionary;
        }
    }


    public class WordLadderVersion1
    {


        private static Dictionary<string, int> _dict = new Dictionary<string, int>();
        private static Dictionary<string, int> _resultSet = new Dictionary<string, int>();
        private static int _result = int.MaxValue;
        private static int _wordLength = 0;
        private static List<string> _bestResult = new List<string>();
        private static List<string> _intermideateResult = new List<string>();
        public static void TestGetLadderLenthVersion1(string start, string end)
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



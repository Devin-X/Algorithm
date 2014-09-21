using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class ReverseWordsInString
    {
        public static string ReverseWords(string str)
        {
            char[] temp = str.Trim().ToCharArray();
            for(int i = 0; i < temp.Length; i++)
            {
                if(temp[i] == ' ')
                {
                    continue;
                }

                int j;
                for(j = i+1; j < temp.Length; j++)
                {
                    if(temp[j]!=' ') continue;
                    else break;
                }

                j--;

                for(int ii = i; ii < j ; ii++,j--)
                {
                    char c = temp[ii];
                    temp[ii] = temp[j];
                    temp[j] = c;
                 }

                i = j + 1;
             }

            for (int i = 0, j = temp.Length - 1; i < j; i++, j--)
            {
                char c = temp[i];
                temp[i] = temp[j];
                temp[j] = c;
            }

            return new string(temp);
        }

        public static void TestReverseWordsInString()
        {
            string s = "the sky is blue";
            Console.WriteLine(ReverseWords(s));
        }
    }
}


//class Solution {
//public:
//    void reverseWords(string &s) {
    
//     for(int i = 0; i < s.length;)
//     {
//       while(s[i] == ' ' && s[i+1] != '\0')
//       {
//           s[i] = s[i+1];
//       }
//     }
     
//     for(int i = 0; i < s.length; i++)
//     {
//         if(s[i] == '')
//         {
//            continue;
//         }
         
//         for(int j = i+1; j < s.length; j++)
//         {
//            if(s[j]!='') continue;
//            else break;
//         }
         
//         j--;
         
//         for(int ii = i; ii < j ; ii++,j--)
//         {
//             char c = s[ii];
//             s[ii] = s[j];
//             s[j] = c;
//         }
//     }
    
//     for(int i = 0,j = s.length -1; i < j; i++,j--)
//     {
//         char c = s[i];
//         s[i] = s[j];
//         s[j] = c;
//     }
//    }
//};
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
            char[] tempWithSpaces = str.Trim().ToCharArray();
            char[] temp = new char[tempWithSpaces.Length];
            for(int i = 0; i < temp.Length; i++)
            {
                temp[i] = ' ';
            }

            int index = 0;
            for (int i = 0; i < tempWithSpaces.Length; i++)
            {
                if (tempWithSpaces[i] == ' ') continue;

                while (i < tempWithSpaces.Length && tempWithSpaces[i] != ' ' )
                {
                    temp[index++] = tempWithSpaces[i++];
                }

                if (index < temp.Length)
                {
                    temp[index++] = ' ';
                }
            }

            --index;
            for (int i = 0; i < index; i++)
            {
                if (temp[i] == ' ')
                {
                    continue;
                }

                int j;
                for (j = i + 1; j < index; j++)
                {
                    if (temp[j] != ' ') continue;
                    else break;
                }

                j--;
                for (int ii = i; ii < j; ii++, j--)
                {
                    char c = temp[ii];
                    temp[ii] = temp[j];
                    temp[j] = c;
                }

                i = j + 1;
            }

            for (int i = 0, j = index - 1; i < j; i++, j--)
            {
                char c = temp[i];
                temp[i] = temp[j];
                temp[j] = c;
            }

            string result = new string(temp);

            return result.Trim();
        }

        public static void TestReverseWordsInString()
        {
            string s = "  the   sky   is   blue  ";
            Console.Write(ReverseWords(s)); Console.Write(ReverseWords(s)); Console.Write(ReverseWords(s));

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
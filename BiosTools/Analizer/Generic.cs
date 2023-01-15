using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BiosTools.Analizer
{
    public class Generic
    {
        public static string[] InvalidTags(string[] Tags, List<string> ValidTags)
        {
            string T = "";
            foreach (string Tag in ValidTags)
            {
                bool Exist = true;
                foreach (string Tag2 in Tags)
                {
                    if (Tag2 == Tag) { Exist = true; }
                    if (Exist == false && Tag2 != " ")
                        T += $"{Tag2} ";
                }
            }

            return T.Length > 0 ? T.Split(' ') : new string[0];
        }

        public static string RemoveDuplicateSpaces(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            string output = Regex.Replace(s, @"\s+", " ");
            return output;
        }

        public static bool Contains(string s, string[] arr)
        {
            foreach (string stg in arr)
                if (s.Equals(stg))
                    return true;

            return false;
        }

        public static int GetIndexOf(string s, string[] arr)
        {
            int Index = -1;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == s)
                    Index = i;

            return Index;
        }

        public static string[] GetArgsVector(string s)
        {
            bool Especial = s.Contains("'");
            if (Especial)
            {
                string Formated = "";
                string tmp = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != ' ')
                        tmp += s[i].ToString();
                    else if (s[i] == ' ')
                    {
                        tmp += '%';
                        Formated += tmp;
                        tmp = string.Empty;
                    }
                    else if (s[i] == '\'')
                    {
                        bool FistIndex = true;
                        while (true)
                        {
                            if (FistIndex)
                            {
                                tmp += s[i].ToString();
                                FistIndex = false;
                            }
                            else
                            {
                                int j = i++;
                                while (j <= (s.Length - 1) && s[j] != '\'')
                                {
                                    tmp += s[j].ToString();
                                    j++;
                                }

                                i = j;
                                tmp += "%";
                                Formated += tmp;
                                tmp = string.Empty;
                                break;
                            }
                        }
                    }
                }

                return Formated.Split('%');
            }
            else
                return s.Split(' ');
        }

        public static string ReverseString(string s)
        {
            string rs = string.Empty;
            for (int i = s.Length - 1; i >= 0; i--)
                rs += s[i].ToString();

            return rs;
        }
    }
}

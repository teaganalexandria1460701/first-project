using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //FuncA();

            FuncB();
        }

        public static void FuncA()
        {
            List<string> result = new List<string>();
            //string str = "";
            string str = "Xin chào   OMT";
            //string str = "Xin chào @KidsOnline";
            //string str = " Xin c{h}ào #KT@!Kids(Online)   ";

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Trim();
                str = Regex.Replace(str, @"\s+", " "); //s => ky tu khoan trang
                str = Regex.Replace(str, @"(@|#|!|\{|\}|\(|\)|\[|\])", "");

                var tempArr = str.Split(" ").Select(x => UppercaseFirst(x)).Reverse().ToList();

                result = tempArr.ToList();
            }
        }

        public static string UppercaseFirst(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        public static void FuncB()
        {
            var listInt = new List<int>();
            //string str = "";
            //string str = "Xin chào  OMT";
            //string str = "Xin chào 123456 @KidsOnline";
            string str = " Xin 20 c{h}ào 60  #KT30@!Kids(Online)  100 ";
            //string str = " Xin 21 c{h}ào 67  #KT30@!Kids(Online)  100 ";

            double result = 0;

            if (!string.IsNullOrEmpty(str))
            {
                var arrSplit = str.Split(" ");

                foreach (var item in arrSplit)
                {
                    //use regex
                    //if (Regex.IsMatch(item, @"^\d+$"))
                    //{
                    //    listInt.Add(int.Parse(item));
                    //}

                    //use tryparse
                    int temp;
                    if(int.TryParse(item, out temp))
                    {
                        listInt.Add(int.Parse(item));
                    }
                }

                if (listInt.Any())
                {
                    result = listInt.Average();

                    var tempStr = result.ToString();

                    var indexDot = tempStr.IndexOf(".");
                    if(indexDot != -1)
                    {
                        var tempResult = tempStr.Substring(0, indexDot + 2);
                        result = double.Parse(tempResult);
                    }
                }
            }
        }
    }
}

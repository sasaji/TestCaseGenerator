using System;
using System.Collections.Generic;

namespace TestCaseGenerator
{
    abstract class TestCase
    {
        public bool PrintText = false;
        public bool NoHeader = false;
        public int Line = 0;

        protected void PrintTestCases(string s, string[] array)
        {
            PrintTestCases(s, array, true);
        }

        protected void PrintTestCases(string s, string[] array, bool print)
        {
            var list = new List<string>();
            for (var i = 0; i < array.Length; i++)
            {
                if (print)
                {
                    if (array[i] == s)
                    {
                        if (PrintText)
                            list.Add(s);
                        else
                            list.Add("●");
                    }
                    else
                        list.Add("");
                }
                else
                    list.Add("");
            }
            Console.Write(string.Join(",", list.ToArray()) + ",");
        }
    }

    public class TestCatego
    {
        public string Name;
        public IList<TestCatego> Tables;
    }
}

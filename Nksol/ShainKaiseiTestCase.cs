using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCaseGenerator.Nksol
{
    class ShainKaiseiTestCase : TestCase
    {
        public void Generate()
        {
            var maedoseis = new string[] { "なし", "1件", "2件" };
            var atodoseis = new string[] { "なし", "1件", "2件" };

            if (!NoHeader)
            {
                Console.Write("#,");
                Console.Write("変更前の同姓同名" + new string(',', maedoseis.Length));
                Console.Write("変更後の同姓同名" + new string(',', atodoseis.Length));
                Console.WriteLine();
                Console.Write(",");
                Console.Write(string.Join(",", maedoseis) + ",");
                Console.Write(string.Join(",", atodoseis) + ",");
                Console.WriteLine();
            }

            foreach (var tekiyobi in maedoseis)
            {
                foreach (var pabupura in atodoseis)
                {
                    Console.Write($"{++Line},");
                    PrintTestCases(tekiyobi, maedoseis);
                    PrintTestCases(pabupura, atodoseis);
                    Console.WriteLine();
                }
            }
        }
    }
}

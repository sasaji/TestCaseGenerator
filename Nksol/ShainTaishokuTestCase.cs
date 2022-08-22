using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCaseGenerator.Nksol
{
    class ShainTaishokuTestCase : TestCase
    {
        public void Generate()
        {
            var line = 0;
            var companies = new string[] { "証券", "グループ会社" };
            var teikis = new string[] { "不定期", "定期" };
            var tekiyobis = new string[] { "なし", "あり(日付あり)", "あり(日付なし)" };
            var pabupuras = new string[] { "なし", "あり" };

            if (!NoHeader)
            {
                Console.Write("#,");
                Console.Write("会社" + new string(',', companies.Length));
                Console.Write("定期異動" + new string(',', teikis.Length));
                Console.Write("適用日指定" + new string(',', tekiyobis.Length));
                Console.Write("パブプラ指定" + new string(',', pabupuras.Length));
                Console.WriteLine();
                Console.Write(",");
                Console.Write(string.Join(",", companies) + ",");
                Console.Write(string.Join(",", teikis) + ",");
                Console.Write(string.Join(",", tekiyobis) + ",");
                Console.Write(string.Join(",", pabupuras) + ",");
                Console.WriteLine();
            }

            foreach (var company in companies)
            {
                foreach (var teiki in teikis)
                {
                    foreach (var tekiyobi in tekiyobis)
                    {
                        foreach (var pabupura in pabupuras)
                        {
                            Console.Write($"{++line},");
                            PrintTestCases(company, companies);
                            PrintTestCases(teiki, teikis);
                            PrintTestCases(tekiyobi, tekiyobis);
                            PrintTestCases(pabupura, pabupuras);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}

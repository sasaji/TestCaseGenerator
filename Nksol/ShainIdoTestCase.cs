using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCaseGenerator.Nksol
{
    class ShainIdoTestCase : TestCase
    {
        public void Generate()
        {
            var companies = new string[] { "証券", "グループ会社" };
            var teikis = new string[] { "不定期", "定期" };
            var tekiyobis = new string[] { "なし", "あり(日付あり)", "あり(日付なし)" };
            var pabupuras = new string[] { "なし", "あり" };
            var henkos = new string[] { "なし", "あり(定期期間外)", "あり(定期期間内)" };
            var gaibuMails = new string[] { "許可→許可", "禁止→許可", "禁止→禁止", "禁止→許可" };

            if (!NoHeader)
            {
                Console.Write("#,");
                Console.Write("会社" + new string(',', companies.Length));
                Console.Write("定期異動" + new string(',', teikis.Length));
                Console.Write("適用日指定" + new string(',', tekiyobis.Length));
                Console.Write("パブプラ指定" + new string(',', pabupuras.Length));
                Console.Write("適用日前の変更" + new string(',', henkos.Length));
                Console.Write("外部メール発信" + new string(',', gaibuMails.Length));
                Console.WriteLine();
                Console.Write(",");
                Console.Write(string.Join(",", companies) + ",");
                Console.Write(string.Join(",", teikis) + ",");
                Console.Write(string.Join(",", tekiyobis) + ",");
                Console.Write(string.Join(",", pabupuras) + ",");
                Console.Write(string.Join(",", henkos) + ",");
                Console.Write(string.Join(",", gaibuMails) + ",");
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
                            foreach (var henko in henkos)
                            {
                                foreach (var gaibuMail in gaibuMails)
                                {
                                    Console.Write($"{++Line},");
                                    PrintTestCases(company, companies);
                                    PrintTestCases(teiki, teikis);
                                    PrintTestCases(tekiyobi, tekiyobis);
                                    PrintTestCases(pabupura, pabupuras);
                                    PrintTestCases(henko, henkos);
                                    PrintTestCases(gaibuMail, gaibuMails);
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

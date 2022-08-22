using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCaseGenerator.Nksol
{
    class ShainNyushaTestCase : TestCase
    {
        public void Generate()
        {
            var companies = new string[] { "証券", "グループ会社(O365利用あり)", "グループ会社(O365利用なし)" };
            var employeeTypes = new string[] { "社員", "派遣" };
            var tenbukas = new string[] { "営業", "営業扱い", "その他" };
            var kenmus = new string[] { "なし", "あり" };
            var yakus = new string[] { "メール可", "メール不可" };
            var flags = new string[] { "メール可", "メール不可" };
            var dosedomes = new string[] { "なし", "あり" };

            var hojincimss = new string[] { "なし", "あり" };
            
            var hojintenbukas = new string[] { "なし", "あり" };
 
            if (!NoHeader)
            {
                Console.WriteLine("syain_denso,,,,,,,,,,,,,,,,hojin-cims,,hojin-tenbuka");
                Console.Write("会社" + new string(',', companies.Length));
                Console.Write("職区分" + new string(',', employeeTypes.Length));
                Console.Write("所属" + new string(',', tenbukas.Length));
                Console.Write("役職" + new string(',', yakus.Length));
                Console.Write("兼務" + new string(',', kenmus.Length));
                Console.Write("メール作成フラグ" + new string(',', flags.Length));
                Console.Write("同姓同名" + new string(',', dosedomes.Length));
                Console.Write("" + new string(',', hojincimss.Length));
                Console.Write("" + new string(',', hojintenbukas.Length));
                Console.WriteLine();
                Console.Write(string.Join(",", companies) + ",");
                Console.Write(string.Join(",", employeeTypes) + ",");
                Console.Write(string.Join(",", tenbukas) + ",");
                Console.Write(string.Join(",", yakus) + ",");
                Console.Write(string.Join(",", kenmus) + ",");
                Console.Write(string.Join(",", flags) + ",");
                Console.Write(string.Join(",", dosedomes) + ",");
                Console.Write(string.Join(",", hojincimss) + ",");
                Console.Write(string.Join(",", hojintenbukas) + ",");
                Console.WriteLine();
            }

            foreach (var company in companies)
            {
                foreach (var employeeType in employeeTypes)
                {
                    foreach (var gender in tenbukas)
                    {
                        foreach (var kenmu in kenmus)
                        {
                            foreach (var yaku in yakus)
                            {
                                foreach (var flag in flags)
                                {
                                    foreach (var dosedome in dosedomes)
                                    {
                                        foreach (var hojincims in hojincimss)
                                        {
                                            foreach (var hojintenbuka in hojintenbukas)
                                            {
                                                PrintTestCases(company, companies);
                                                PrintTestCases(employeeType, employeeTypes);
                                                PrintTestCases(gender, tenbukas);
                                                PrintTestCases(yaku, yakus);
                                                PrintTestCases(kenmu, kenmus);
                                                PrintTestCases(flag, flags);
                                                PrintTestCases(dosedome, dosedomes);
                                                PrintTestCases(hojincims, hojincimss);
                                                PrintTestCases(hojintenbuka, hojintenbukas);
                                                Console.WriteLine();
                                                // flagの下のループは1回目だけ
                                                //if (flag != flags.First()) break;
                                            }
                                            // flagの下のループは1回目だけ
                                            //if (flag != flags.First()) break;
                                        }
                                        // flagの下のループは1回目だけ
                                        //if (flag != flags.First()) break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

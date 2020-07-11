using System;

namespace TestCaseGenerator.Sshd.Ten5
{
    class PersonsTestCase : TestCase
    {
        public void Generate()
        {
            var middleNames = new string[] { "なし", "あり" };
            var gaijis = new string[] { "なし", "あり" };
            var genders = new string[] { "男性", "女性" };
            var phones = new string[] { "なし", "あり" };
            var kenmus = new string[] { "なし", "あり" };
            var status = new string[] { "有効", "無効", "なし" };
            var expires = new string[] { "なし", "あり" };
            var emails = new string[] { "あり", "なし" };
            var quotas = new string[] { "1MB", "5MB" };
            var books = new string[] { "表示", "非表示" };
            var externals = new string[] { "可", "不可" };

            if (!NoHeader)
            {
                Console.Write(string.Join(",", middleNames) + ",");
                Console.Write(string.Join(",", gaijis) + ",");
                Console.Write(string.Join(",", genders) + ",");
                Console.Write(string.Join(",", phones) + ",");
                Console.Write(string.Join(",", kenmus) + ",");
                Console.Write(string.Join(",", status) + ",");
                Console.Write(string.Join(",", expires) + ",");
                Console.Write(string.Join(",", emails) + ",");
                Console.Write(string.Join(",", quotas) + ",");
                Console.Write(string.Join(",", books) + ",");
                Console.Write(string.Join(",", externals) + ",");
                Console.WriteLine();
            }

            foreach (var middleName in middleNames)
            {
                foreach (var gaiji in gaijis)
                {
                    foreach (var gender in genders)
                    {
                        foreach (var phone in phones)
                        {
                            foreach (var kenmu in kenmus)
                            {
                                foreach (var state in status)
                                {
                                    foreach (var expire in expires)
                                    {
                                        foreach (var email in emails)
                                        {
                                            foreach (var quota in quotas)
                                            {
                                                foreach (var book in books)
                                                {
                                                    foreach (var external in externals)
                                                    {
                                                        PrintTestCases(middleName, middleNames);
                                                        PrintTestCases(gaiji, gaijis);
                                                        PrintTestCases(gender, genders);
                                                        PrintTestCases(phone, phones);
                                                        PrintTestCases(kenmu, kenmus);
                                                        PrintTestCases(state, status);
                                                        PrintTestCases(expire, expires, state != "なし");
                                                        PrintTestCases(email, emails, state != "なし");
                                                        PrintTestCases(quota, quotas, state != "なし" && email == "あり");
                                                        PrintTestCases(book, books, state != "なし" && email == "あり");
                                                        PrintTestCases(external, externals, state != "なし" && email == "あり");
                                                        Console.WriteLine();
                                                        if (state == "なし" || email == "なし") break;
                                                    }
                                                    if (state == "なし" || email == "なし") break;
                                                }
                                                if (state == "なし" || email == "なし") break;
                                            }
                                            if (state == "なし") break;
                                        }
                                        if (state == "なし") break;
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

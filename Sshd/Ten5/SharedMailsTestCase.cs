using System;

namespace TestCaseGenerator.Sshd.Ten5
{
    class SharedMailsTestCase : TestCase
    {
        public void Generate()
        {
            var accessRights = new string[] { "ユーザー", "グループ", "両方", "なし" };
            var externals = new string[] { "不可", "可" };
            var quotas = new string[] { "1MB", "5MB" };
            var books = new string[] { "表示", "非表示" };

            if (!NoHeader)
            {
                Console.Write(string.Join(",", accessRights) + ",");
                Console.Write(string.Join(",", externals) + ",");
                Console.Write(string.Join(",", quotas) + ",");
                Console.Write(string.Join(",", books) + ",");
                Console.WriteLine();
            }

            foreach (var middleName in accessRights)
            {
                foreach (var external in externals)
                {
                    foreach (var quota in quotas)
                    {
                        foreach (var book in books)
                        {
                            PrintTestCases(middleName, accessRights);
                            PrintTestCases(external, externals);
                            PrintTestCases(quota, quotas);
                            PrintTestCases(book, books);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}

using System;

namespace TestCaseGenerator.Leo
{
    class TitleAddressBookTestCase : TestCase
    {
        public void Generate()
        {
            var userFiles = new string[] { "連携", "連携外", "なし" };
            var operationFlags = new string[] { "A", "空", "D" };
            var shozokuFiles = new string[] { "主務", "兼務同階層", "兼務別階層", "なし" };
            var deptFiles = new string[] { "1", "2", "3", "4" };
            var titleFiles = new string[] { "階層あり", "階層なし", "未定義" };
            var daihyos = new string[] { "×", "○" };
            var addressBooks = new string[] { "あり同階層", "あり別階層", "なし" };
            var diffs = new string[] { "あり", "なし" };

            if (!NoHeader)
            {
                Console.Write(string.Join(",", userFiles) + ",");
                Console.Write(string.Join(",", operationFlags) + ",");
                Console.Write(string.Join(",", shozokuFiles) + ",");
                Console.Write(string.Join(",", deptFiles) + ",");
                Console.Write(string.Join(",", titleFiles) + ",");
                Console.Write(string.Join(",", daihyos) + ",");
                Console.Write(string.Join(",", addressBooks) + ",");
                Console.Write(string.Join(",", diffs) + ",");
                Console.WriteLine("Do");
            }

            foreach (var userFile in userFiles)
            {
                foreach (var operationFlag in operationFlags)
                {
                    foreach (var shozokuFile in shozokuFiles)
                    {
                        foreach (var deptFile in deptFiles)
                        {
                            foreach (var titleFile in titleFiles)
                            {
                                foreach (var daihyo in daihyos)
                                {
                                    foreach (var addressBook in addressBooks)
                                    {
                                        if (shozokuFile == "なし" && addressBook == "あり別階層") continue;
                                        foreach (var diff in diffs)
                                        {
                                            PrintTestCases(userFile, userFiles);
                                            PrintTestCases(operationFlag, operationFlags, userFile != "なし");
                                            PrintTestCases(shozokuFile, shozokuFiles);
                                            PrintTestCases(deptFile, deptFiles, shozokuFile != "なし");
                                            PrintTestCases(titleFile, titleFiles, shozokuFile != "なし");
                                            PrintTestCases(daihyo, daihyos, shozokuFile != "なし");
                                            PrintTestCases(addressBook, addressBooks);
                                            PrintTestCases(diff, diffs, addressBook != "なし" && shozokuFile != "なし");
                                            Console.WriteLine();
                                            if (addressBook == "なし" || shozokuFile == "なし") break;
                                        }
                                    }
                                    if (shozokuFile == "なし") break;
                                }
                                if (shozokuFile == "なし") break;
                            }
                            if (shozokuFile == "なし") break;
                        }
                    }
                    if (userFile == "なし") break;
                }
            }
        }
    }
}

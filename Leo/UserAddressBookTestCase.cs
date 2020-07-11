using System;

namespace TestCaseGenerator.Leo
{
    class UserAddressBookTestCase : TestCase
    {
        public void Generate()
        {
            var userFiles = new string[] { "連携", "連携外", "なし" };
            var operationFlags = new string[] { "A", "空", "D" };
            var shozokuFiles = new string[] { "主務", "兼務", "なし" };
            var addressBooks = new string[] { "あり同階層", "あり別階層", "なし" };
            var diffs = new string[] { "あり", "なし" };

            if (!NoHeader)
            {
                Console.Write(string.Join(",", userFiles) + ",");
                Console.Write(string.Join(",", operationFlags) + ",");
                Console.Write(string.Join(",", shozokuFiles) + ",");
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
                        foreach (var addressBook in addressBooks)
                        {
                            if (shozokuFile == "なし" && addressBook == "あり別階層") continue;
                            foreach (var diff in diffs)
                            {
                                PrintTestCases(userFile, userFiles);
                                PrintTestCases(operationFlag, operationFlags, userFile != "なし");
                                PrintTestCases(shozokuFile, shozokuFiles);
                                PrintTestCases(addressBook, addressBooks);
                                PrintTestCases(diff, diffs, addressBook != "なし" && shozokuFile != "なし");
                                Console.WriteLine();
                                if (addressBook == "なし" || shozokuFile == "なし") break;
                            }
                        }
                    }
                    if (userFile == "なし") break;
                }
            }
        }
    }
}

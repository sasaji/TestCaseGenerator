using System;

namespace TestCaseGenerator.Leo
{
    class MembershipTestCase : TestCase
    {
        public void Generate()
        {
            var userFiles = new string[] { "連携", "連携外", "なし" };
            var operationFlags = new string[] { "A", "空", "D" };
            var shozokuFiles = new string[] { "主務", "兼務", "なし" };
            var deptFiles = new string[] { "あり", "なし" };
            var adUsers = new string[] { "あり", "なし" };
            var memberships = new string[] { "あり", "なし" };

            if (!NoHeader)
            {
                Console.Write(string.Join(",", userFiles) + ",");
                Console.Write(string.Join(",", operationFlags) + ",");
                Console.Write(string.Join(",", shozokuFiles) + ",");
                Console.Write(string.Join(",", deptFiles) + ",");
                Console.Write(string.Join(",", adUsers) + ",");
                Console.Write(string.Join(",", memberships) + ",");
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
                            foreach (var adUser in adUsers)
                            {
                                foreach (var membership in memberships)
                                {
                                    PrintTestCases(userFile, userFiles);
                                    PrintTestCases(operationFlag, operationFlags, userFile != "なし");
                                    PrintTestCases(shozokuFile, shozokuFiles);
                                    PrintTestCases(deptFile, deptFiles, !(shozokuFile == "なし" && membership == "なし"));
                                    PrintTestCases(adUser, adUsers);
                                    PrintTestCases(membership, memberships, adUser != "なし");
                                    Console.WriteLine();
                                    if (adUser == "なし") break;
                                }
                            }
                        }
                    }
                    if (userFile == "なし") break;
                }
            }
        }
    }
}

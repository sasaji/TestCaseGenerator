using System;

namespace TestCaseGenerator.Leo
{
    class MembershipChangeTestCase : TestCase
    {
        public void Generate()
        {
            var currentShumus = new string[] { "1", "2", "3", "4" };
            var currentKenmus = new string[] { "なし", "役職同階層", "役職別階層" };
            var currentTitles = new string[] { "階層あり", "階層なし", "代表", "未定義" };
            var userFiles = new string[] { "連携", "連携外", "なし" };
            var operationFlags = new string[] { "A", "空", "D" };
            var newShumus = new string[] { "変更なし", "既→既", "既→新", "削→既", "削→新", "兼→主", "入替" };
            var newKenmus = new string[] { "変更なし", "なし", "役職同階層", "役職別階層", "入替" };
            var newTitles = new string[] { "変更なし", "階層あり", "階層なし", "代表", "未定義" };

            if (!NoHeader)
            {
                Console.Write(string.Join(",", currentShumus) + ",");
                Console.Write(string.Join(",", currentKenmus) + ",");
                Console.Write(string.Join(",", currentTitles) + ",");
                Console.Write(string.Join(",", userFiles) + ",");
                Console.Write(string.Join(",", operationFlags) + ",");
                Console.Write(string.Join(",", newShumus) + ",");
                Console.Write(string.Join(",", newKenmus) + ",");
                Console.Write(string.Join(",", newTitles) + ",");
                Console.WriteLine("Do");
            }

            foreach (var currentShumu in currentShumus)
            {
                foreach (var currentKenmu in currentKenmus)
                {
                    foreach (var currentTitle in currentTitles)
                    {
                        foreach (var userFile in userFiles)
                        {
                            foreach (var operationFlag in operationFlags)
                            {
                                foreach (var newShumu in newShumus)
                                {
                                    if (currentKenmu == "なし" && newShumu == "入替") continue;
                                    foreach (var newKenmu in newKenmus)
                                    {
                                        if (newShumu == "兼→主" && newKenmu == "変更なし") continue;
                                        if (newShumu == "入替" && newKenmu != "入替") continue;
                                        if (currentKenmu == "なし" && newKenmu == "変更なし") continue;
                                        if (currentKenmu == "なし" && newKenmu == "入替") continue;
                                        foreach (var newTitle in newTitles)
                                        {
                                            PrintTestCases(currentShumu, currentShumus);
                                            PrintTestCases(currentKenmu, currentKenmus);
                                            PrintTestCases(currentTitle, currentTitles);
                                            PrintTestCases(userFile, userFiles);
                                            PrintTestCases(operationFlag, operationFlags, userFile != "なし");
                                            PrintTestCases(newShumu, newShumus, userFile != "なし" && operationFlag != "D");
                                            PrintTestCases(newKenmu, newKenmus, userFile != "なし" && operationFlag != "D");
                                            PrintTestCases(newTitle, newTitles, userFile != "なし" && operationFlag != "D");
                                            Console.WriteLine();
                                            if (userFile == "なし") break;
                                            if (operationFlag == "D") break;
                                        }
                                        if (userFile == "なし") break;
                                        if (operationFlag == "D") break;
                                    }
                                    if (userFile == "なし") break;
                                    if (operationFlag == "D") break;
                                }
                                if (userFile == "なし") break;
                            }
                        }
                    }
                }
            }
        }

        public void Generatex()
        {
            var currentShumus = new string[] { "1", "2", "3", "4" };
            var currentKenmus = new string[] { "なし", "1", "2", "3", "4" };
            //var currents = new string[] { "主務のみ", "兼務あり" };
            var userFiles = new string[] { "連携", "連携外", "なし" };
            var operationFlags = new string[] { "A", "空", "D" };
            var shumuPatterns = new string[] { "変更なし", "既→既", "既→新", "削→既", "削→新", "兼→主", "入替" };
            var shumuKaisos = new string[] { "なし", "あり" };
            var kenmuPatterns = new string[] { "変更なし", "追加", "既→既", "既→新", "削→既", "削→新", "入替", "削除" };
            var kenmuKaisos = new string[] { "なし", "あり" };

            if (!NoHeader)
            {
                Console.Write(string.Join(",", currentShumus) + ",");
                Console.Write(string.Join(",", currentKenmus) + ",");
                Console.Write(string.Join(",", userFiles) + ",");
                Console.Write(string.Join(",", operationFlags) + ",");
                Console.Write(string.Join(",", shumuPatterns) + ",");
                Console.Write(string.Join(",", shumuKaisos) + ",");
                Console.Write(string.Join(",", kenmuPatterns) + ",");
                Console.Write(string.Join(",", kenmuKaisos) + ",");
                Console.WriteLine("Do");
            }

            foreach (var currentShumu in currentShumus)
            {
                foreach (var currentKenmu in currentKenmus)
                {
                    foreach (var userFile in userFiles)
                    {
                        foreach (var operationFlag in operationFlags)
                        {
                            foreach (var shumuPattern in shumuPatterns)
                            {
                                foreach (var shumuKaiso in shumuKaisos)
                                {
                                    if (shumuPattern == "変更なし" && shumuKaiso != "なし") continue;
                                    foreach (var kenmuPattern in kenmuPatterns)
                                    {
                                        if (currentKenmu == "なし" && kenmuPattern != "変更なし" && kenmuPattern != "追加") continue;
                                        if (shumuPattern == "兼→主" && kenmuPattern != "削除") continue;
                                        if (shumuPattern == "入替" && kenmuPattern != "入替") continue;
                                        foreach (var kenmuKaiso in kenmuKaisos)
                                        {
                                            if (kenmuPattern == "変更なし" && kenmuKaiso != "なし") continue;
                                            PrintTestCases(currentShumu, currentShumus);
                                            PrintTestCases(currentKenmu, currentKenmus);
                                            PrintTestCases(userFile, userFiles);
                                            PrintTestCases(operationFlag, operationFlags, userFile != "なし");
                                            PrintTestCases(shumuPattern, shumuPatterns, userFile != "なし" && operationFlag != "D");
                                            PrintTestCases(shumuKaiso, shumuKaisos, userFile != "なし" && operationFlag != "D");
                                            PrintTestCases(kenmuPattern, kenmuPatterns, userFile != "なし" && operationFlag != "D");
                                            PrintTestCases(kenmuKaiso, kenmuKaisos, currentKenmu != "なし" && userFile != "なし" && operationFlag != "D");
                                            Console.WriteLine();
                                            if (currentKenmu == "なし") break;
                                            if (userFile == "なし") break;
                                            if (operationFlag == "D") break;
                                        }
                                    }
                                    if (userFile == "なし") break;
                                    if (operationFlag == "D") break;
                                }
                            }
                            if (userFile == "なし") break;
                        }
                    }
                }
            }
        }
    }
}

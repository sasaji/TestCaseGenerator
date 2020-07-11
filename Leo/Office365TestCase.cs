using System;

namespace TestCaseGenerator.Leo
{
    class Office365TestCase : TestCase
    {
        public void Generate()
        {
            var inputFiles = new string[] { "連携", "連携外", "なし" };
            var licenseFlags = new string[] { "E1", "F1", "Kiosk", "Plan1" };
            var operationFlags = new string[] { "A", "空", "D" };
            var adStatus = new string[] { "ユーザー正常", "ユーザーsyncなし", "ユーザーmailなし", "連絡先正常", "連絡先syncなし", "連絡先mailなし", "なし" };
            var o365Types = new string[] { "フェデレーション", "クラウド", "なし" };
            var o365Licenses = new string[] { "ライセンスなし", "同ライセンス", "別ライセンス" };
            var exos = new string[] { "未設定", "設定済み" };

            if (!NoHeader)
            {
                Console.Write(string.Join(",", inputFiles) + ",");
                Console.Write(string.Join(",", licenseFlags) + ",");
                Console.Write(string.Join(",", operationFlags) + ",");
                Console.Write(string.Join(",", adStatus) + ",");
                Console.Write(string.Join(",", o365Types) + ",");
                Console.Write(string.Join(",", o365Licenses) + ",");
                Console.Write(string.Join(",", exos) + ",");
                Console.WriteLine("Do");
            }

            foreach (var inputFile in inputFiles)
            {
                foreach (var licenseFlag in licenseFlags)
                {
                    if (inputFile == "連携" && licenseFlag != "E1") continue;
                    if (inputFile == "連携外" && licenseFlag == "E1") continue;
                    foreach (var operationFlag in operationFlags)
                    {
                        foreach (var adState in adStatus)
                        {
                            foreach (var o365Type in o365Types)
                            {
                                if (adState.EndsWith("なし") && o365Type == "フェデレーション") continue;
                                if (adState == "連絡先正常" && o365Type == "フェデレーション") continue;
                                foreach (var o365License in o365Licenses)
                                {
                                    if (adState == "連絡先正常" && o365License != "ライセンスなし") continue;
                                    foreach (var exo in exos)
                                    {
                                        if (o365License == "ライセンスなし" && exo != "未設定") continue;
                                        PrintTestCases(inputFile, inputFiles);
                                        PrintTestCases(licenseFlag, licenseFlags, inputFile != "なし");
                                        PrintTestCases(operationFlag, operationFlags, inputFile != "なし");
                                        PrintTestCases(adState, adStatus);
                                        PrintTestCases(o365Type, o365Types);
                                        PrintTestCases(o365License, o365Licenses, adState.StartsWith("ユーザー") && o365Type != "なし");
                                        PrintTestCases(exo, exos, adState.StartsWith("ユーザー") && o365Type != "なし");
                                        Console.WriteLine(Do(inputFile, licenseFlag, operationFlag, adState, o365Type, o365License, exo));
                                        if (o365Type == "なし") break;
                                    }
                                    if (o365Type == "なし") break;
                                }
                            }
                        }
                        if (inputFile == "なし") break;
                    }
                    if (inputFile == "なし") break;
                }
            }
        }

        public string Do(string inputFile, string licenseFlag, string operationFlag, string adState, string o365Type, string o365License, string exo)
        {
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "ユーザー正常" && o365Type == "フェデレーション" && o365License == "ライセンスなし" && exo == "未設定") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "ユーザー正常" && o365Type == "フェデレーション" && o365License == "同ライセンス" && exo == "未設定") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "ユーザー正常" && o365Type == "フェデレーション" && o365License == "同ライセンス" && exo == "設定済み") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "ユーザー正常" && o365Type == "フェデレーション" && o365License == "別ライセンス" && exo == "未設定") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "ユーザー正常" && o365Type == "なし") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "ユーザーsyncなし" && o365Type == "クラウド" && o365License == "別ライセンス" && exo == "未設定") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "ユーザーsyncなし" && o365Type == "なし") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "ユーザーmailなし" && o365Type == "なし") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "連絡先正常" && o365Type == "クラウド" && o365License == "ライセンスなし") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "なし" && o365Type == "クラウド" && o365License == "ライセンスなし") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "なし" && o365Type == "クラウド" && o365License == "同ライセンス" && exo == "設定済み") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "A" && adState == "なし" && o365Type == "なし") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "空" && adState == "ユーザー正常" && o365Type == "フェデレーション" && o365License == "同ライセンス" && exo == "設定済み") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "空" && adState == "ユーザーsyncなし" && o365Type == "なし") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "空" && adState == "なし" && o365Type == "なし") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "D" && adState == "ユーザー正常" && o365Type == "フェデレーション" && o365License == "ライセンスなし" && exo == "未設定") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "D" && adState == "ユーザーsyncなし" && o365Type == "なし") return "●";
            if (inputFile == "連携" && licenseFlag == "E1" && operationFlag == "D" && adState == "なし" && o365Type == "なし") return "●";
            if (inputFile == "連携外" && licenseFlag == "F1" && operationFlag == "A" && adState == "ユーザー正常" && o365Type == "フェデレーション" && o365License == "ライセンスなし" && exo == "未設定") return "●";
            if (inputFile == "連携外" && licenseFlag == "F1" && operationFlag == "A" && adState == "ユーザー正常" && o365Type == "フェデレーション" && o365License == "別ライセンス" && exo == "設定済み") return "●";
            if (inputFile == "連携外" && licenseFlag == "Kiosk" && operationFlag == "A" && adState == "ユーザー正常" && o365Type == "フェデレーション" && o365License == "ライセンスなし" && exo == "未設定") return "●";
            if (inputFile == "連携外" && licenseFlag == "Plan1" && operationFlag == "A" && adState == "ユーザー正常" && o365Type == "フェデレーション" && o365License == "ライセンスなし" && exo == "未設定") return "●";
            return string.Empty;
        }
    }
}

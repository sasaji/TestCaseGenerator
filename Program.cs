using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCaseGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Leo.Office365TestCase().Generate();
            //new Leo.MembershipTestCase().Generate();
            //new Leo.UserAddressBookTestCase().Generate();
            //new Leo.TitleAddressBookTestCase().Generate();
            //new Leo.MembershipChangeTestCase().Generate();

            //new Sshd.Ten5.PersonsTestCase().Generate();
            new Sshd.Ten5.SharedMailsTestCase().Generate();
        }

        static void Test()
        {
            var tests = new TestCategory()
            {
                Name = "root",
                SubCategories = new List<TestCategory>()
                {
                    new TestCategory() {
                        Name = "ユーザー",
                        SubCategories = new List<TestCategory>()
                        {
                            new TestCategory()
                            {
                                Name = "連携"
                            },
                            new TestCategory()
                            {
                                Name = "連携外"
                            },
                            new TestCategory()
                            {
                                Name = "なし"
                            }
                        }
                    },
                    new TestCategory()
                    {
                        Name = "ユーザーCSVファイル",
                        SubCategories = new List<TestCategory>()
                        {
                            new TestCategory()
                            {
                                Name = "ライセンス識別子",
                                SubCategories = new List<TestCategory>()
                                {
                                    new TestCategory()
                                    {
                                        Name = "E1"
                                    },
                                    new TestCategory()
                                    {
                                        Name = "F1"
                                    }
                                }
                            },
                            new TestCategory()
                            {
                                Name = "なし"
                            }
                        }
                    }
                }
            };
            Console.WriteLine(Depth(tests, 0));
            Console.WriteLine(Length(tests, 0));
            Print(tests, Length(tests, 0));
            Search(tests);
        }

        static int Depth(TestCategory root, int depth)
        {
            int result = depth + 1;
            foreach (var node in root.SubCategories)
                result = Math.Max(result, Depth(node, depth + 1));
            return result;
        }

        static int Length(TestCategory root, int length)
        {
            int result = length + root.SubCategories.Count(e => e.SubCategories.Count == 0);
            foreach (var node in root.SubCategories.Where(e => e.SubCategories.Count > 0))
                result = Length(node, result);
            return result;
        }

        static void Print(TestCategory root, int length)
        {
            Console.WriteLine(root.Name + new string(',', length));
            foreach (var node in root.SubCategories)
                Print(node, Length(node, 0));
        }

        public static void Search(TestCategory root)
        {
            var queue = new Queue<TestCategory>();
            root.Visited = true;
            //Visit(root);
            Console.WriteLine(root.Name + new string(',', Length(root, 0)));
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var current_node = queue.Dequeue();
                if (current_node.SubCategories != null)
                {
                    foreach (var node in current_node.SubCategories)
                    {
                        if (!node.Visited)
                        {
                            //Visit(node);
                            Console.Write(node.Name + new string(',', Length(node, 0)));
                            node.Visited = true;
                            queue.Enqueue(node);
                        }
                    }
                }
                //Console.WriteLine();
            }
        }
    }
}

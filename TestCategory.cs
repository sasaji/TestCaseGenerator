using System.Collections.Generic;

namespace TestCaseGenerator
{
    class TestCategory
    {
        public string Name;
        public List<TestCategory> SubCategories = new List<TestCategory>();
        public bool Visited;
    }
}

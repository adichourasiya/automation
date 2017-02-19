using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework
{
    public class TestBase
    {
        [TestInitialize]
        public static void Initialize()
        {
            Browser.Initialize();
        }

        public static void TestFixtureTearDown()
        {
            Browser.Close();
        }

        [TestCleanup]
        public static void TearDown()
        {
            Browser.Close();
        }
    }
}

using CognizantSoftvision.Maqs.BaseTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Session1Homework : BaseTest
    {

        [TestMethod]
        public void SampleTestSession1()
        {
            this.TestObject.Log.LogMessage("Start Session 1 Test");
            Assert.IsTrue(true, "True is Not True");
        }
    }
}

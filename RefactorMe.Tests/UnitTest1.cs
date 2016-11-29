using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe;

namespace RefactorMe.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProductDataConsolidator instance = new ProductDataConsolidator();
            var plist = instance.Get(State.NZ);
            var plist2 = instance.Get(State.US);
            var plist3 = instance.Get(State.EURO);
        }
    }
}

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise.Composite.Test
{
    [TestClass]
    public class CompositeParentTest
    {
        [TestMethod]
        public void InitRecrusiveChild_Test()
        {
            var group = FakeStorage.GetSimpleGroup();

            group.InitChildsRecrusive();

            var miro = group.Users.Single(a => a.Name == "Miro");

            Assert.AreEqual(miro.Parent, group);

            var mirosRedCar = miro.Cars.Single(a => a.Color == "Red");

            Assert.AreEqual(miro, mirosRedCar.Parent);
        }
    }
}

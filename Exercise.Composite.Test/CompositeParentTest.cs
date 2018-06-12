using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void VizualizeTree_Test()
        {
            var group = FakeStorage.GetSimpleGroup();

            group.InitChildsRecrusive();

            var actual = group.VizualizeTree();

            var expected =
@"Group: Root Group
 - User: Miro
 -- Car: Red
 -- Car: Blue
 - User: John
 -- Car: Black
";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvokeBubbleDown_Test()
        {
            var group = FakeStorage.GetSimpleGroup();

            group.InitChildsRecrusive();

            var actual = group.InvokeBubbleDown(string.Empty);

            var expected = ",User: Miro,Car: Red,Car: Blue,User: John,Car: Black";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvokeBubbleDownNonCummulative_Test()
        {
            var group = FakeStorage.GetSimpleGroup();

            group.InitChildsRecrusive();

            var actual = group.InvokeBubbleDownNonCummulative(group.ToString()).ToList();

            var expected = new List<string>
            {
                "Group: Root Group,User: Miro,Car: Red",
                "Group: Root Group,User: Miro,Car: Blue",
                "Group: Root Group,User: John,Car: Black"
            };

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}

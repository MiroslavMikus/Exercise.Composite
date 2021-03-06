﻿using Exercise.Composite.CompositeExtensions;
using Exercise.Composite.CompositeInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Composite.Test
{
    [TestClass]
    public class CompositeChildTest
    {
        [TestMethod]
        public void BuildStackToRoot_Test()
        {
            var group = UserModel.FakeStorage.GetSimpleGroup();

            group.InitChildsRecrusive();

            var miro = group.Users.Single(a => a.Name == "Miro");

            var mirosRedCar = miro.Cars.Single(a => a.Color == "Red");

            var actual = mirosRedCar.BuildStackToRoot();

            var expected = new Stack<ICompositeChild<string>>();

            expected.Push(mirosRedCar);

            expected.Push(miro);

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}

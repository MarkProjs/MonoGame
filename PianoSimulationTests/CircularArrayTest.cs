using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoSimulation;

namespace PianoSimulationTests
{
    [TestClass]
    public class CircularArrayTest
    {
        [TestMethod]
        public void TestLength()
        {
            CircularArray CArr = new CircularArray(2);
            Assert.AreEqual(CArr.Length,2);
        }
        [TestMethod]
        public void TestShift() {
            CircularArray CArr = new CircularArray(3);
            double[] Arr = {0.5, 0.2, 0.05};
            CArr.Fill(Arr);

            CArr.Shift(0.1);
            Assert.AreEqual(0.1, CArr[0]);
            
            CArr.Shift(0.3);
            Assert.AreEqual(0.3, CArr[1]);
            CArr.Shift(0.04);
            Assert.AreEqual(0.04, CArr[2]);
            CArr.Shift(0.5);
            Assert.AreEqual(0.5, CArr[0]);

        }

    }
}

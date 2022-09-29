using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoSimulation;

namespace PianoSimulationTests
{
    [TestClass]
    public class PinoTest
    {
        [TestMethod]
        public void TestGetPianoKeys() {
            Piano piano = new Piano();
            List<string> PianoKeys = piano.GetPianoKeys();
            Assert.AreEqual(PianoKeys[0], "Key: q Note Frequency: 110");
            Assert.AreEqual(PianoKeys[1], "Key: 2 Note Frequency: 116.54094037952248");
            Assert.AreEqual(PianoKeys[2], "Key: w Note Frequency: 123.47082531403103");
            Assert.AreEqual(PianoKeys[3], "Key: e Note Frequency: 130.8127826502993");
        }
    }
}
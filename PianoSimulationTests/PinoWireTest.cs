using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoSimulation;

namespace PianoSimulationTests
{
    [TestClass]
    public class PinoWireTest
    {
        [TestMethod]
        public void TestNoteFreq()
        {
            PianoWire pw = new PianoWire(0.5, 2);
            Assert.AreEqual(pw.NoteFrequency, 0.5);
        }

        [TestMethod]
        public void TestNumSample()
        {
            PianoWire pw = new PianoWire(0.5, 2);
            Assert.AreEqual(pw.NumberOfSamples, 4);
        }


        [TestMethod]
        public void TestCircArr()
        {
            PianoWire pw = new PianoWire(0.5, 2);
            Assert.AreEqual(pw.NoteArr.Length, 4);
        }

        [TestMethod]
        public void TestSample()
        {
            PianoWire pw = new PianoWire(0.5, 4);
            pw.Strike();

            Assert.AreEqual(pw.NoteArr[0], pw.Sample());

        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PianoSimulation
{
    public class PianoWire:IMusicalString
    {
        private CircularArray _circArr;
        private double _noteFreq;
        private int _numSamples;

        private double FirstBuffer = 0.0;
        private double SecondBuffer = 0.0;

        public PianoWire(double NoteFreq, int SampleRate) {
            _noteFreq = NoteFreq;
            _numSamples = Convert.ToInt32(SampleRate/NoteFreq);
            _circArr = new CircularArray(_numSamples);

        }

        public double NoteFrequency{
            get {
                return _noteFreq;
            }

        }

        public int NumberOfSamples {
            get {
                return _numSamples;
            }
        }

        public CircularArray NoteArr {
            get {
                return _circArr;
            }
        }

        public void Strike() {
            Random rand = new Random();
            double MIN_VALUE = -0.5;
            double MAX_VALUE = 0.5;
            double[] tempArr = new double[_circArr.Length];
            for (int i = 0; i < tempArr.Length;i++) {
                tempArr[i] = Math.Round((rand.NextDouble() * (MAX_VALUE - MIN_VALUE) + MIN_VALUE),4);
            }

            _circArr.Fill(tempArr);
            
        }

        public double Sample(double decay=0.996) {
            if (_circArr.Counter == _circArr.Length -1) {
                FirstBuffer = _circArr[_circArr.Counter -1];
                SecondBuffer = _circArr[0];
            }
            else {
                FirstBuffer = _circArr[_circArr.Counter];
                SecondBuffer = _circArr[_circArr.Counter + 1];
            }
            double newValue = ((FirstBuffer + SecondBuffer) / 2) * decay;
            return _circArr.Shift(newValue);
        }
    }
}
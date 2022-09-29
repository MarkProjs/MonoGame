using System;
using System.Linq;

namespace PianoSimulation
{
    public class CircularArray:IRingBuffer {   
        private double[] buffer;
        private int _counter = 0;

        public CircularArray(int arrLength) {
            buffer = new double[arrLength];
        }
        public int Length {
            get { return buffer.Length;}
               
            
        }

        public int Counter {
            get { return _counter;}
            set {_counter = value;}
        }

        public double Shift(double value) {
            double FirstVal = buffer[_counter];
            buffer[_counter] = value;
            if (_counter == buffer.Length -1) {
                _counter = 0;
            }
            else {
                _counter += 1;
            }
            return FirstVal;
        }

        public double this[int index] {
            get {return buffer[index];}
        }

        public void Fill(double[] array) {
            double[] tempArr = new double[array.Length];
            for(int i = 0; i < array.Length ; i++) {
                tempArr[i] = array[i];
            }

            buffer = tempArr;
        }
        
    }
}
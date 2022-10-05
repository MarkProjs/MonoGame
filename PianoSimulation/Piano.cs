using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PianoSimulation
{
    public class Piano:IPiano {
        private List<IMusicalString> _pianoWires = new List<IMusicalString>();

        public Piano(string keys = "q2we4r5ty7u8i9op-[=zxdcfvgbnjmk,.;/' ",  int samplingRate = 44100) {
            Keys = keys;
            for (int i = 0; i < Keys.Length;i++) {
                double frequency = Math.Pow(2,(i-24)/12.0)*440;
                _pianoWires.Add(new PianoWire(frequency, samplingRate));
            }
        }

        public void StrikeKey(char key) {
            int index = Keys.IndexOf(key);
            _pianoWires[index].Strike();
        }

        public double Play() {
            double sumSample = 0.0;
            for (int i = 0;i < _pianoWires.Count;i++) {
                sumSample += _pianoWires[i].Sample();
            }
            return sumSample;
        }

        public List<string> GetPianoKeys() {
            List<string> pianoKeys = new List<string>();
            for (int i = 0; i < Keys.Length;i++) {
                pianoKeys.Add("Key: " + Keys[i] +  " Note Frequency: " + _pianoWires[i].NoteFrequency);
            }

            return pianoKeys;
        }

        public string Keys { get;}
    }
}
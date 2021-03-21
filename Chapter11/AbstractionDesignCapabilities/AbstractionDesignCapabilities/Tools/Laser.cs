using System.IO;
using AbstractionDesignCapabilities.Interfaces;

namespace AbstractionDesignCapabilities.Tools
{
    public class Laser : ISensor, IMovable, IMeasurable
    {
        private float _x, _y;

        public float Measure()
        {
            return 0f;
        }
        public void WriteMeasurement(TextWriter writer)
        {
            writer.WriteLine(Measure());
        }

        public string GetName()
        {
            return "laser";
        }

        public void Move(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
}

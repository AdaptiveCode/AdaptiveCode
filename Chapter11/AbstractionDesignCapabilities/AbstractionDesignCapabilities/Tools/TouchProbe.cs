using System.IO;
using AbstractionDesignCapabilities.Interfaces;

namespace AbstractionDesignCapabilities.Tools
{
    public class TouchProbe : ISensor, IMovable, IRotatable, IHeightAdjustable, IMeasurable
    {
        private float _x, _y;
        private float _pitch;
        private float _roll;
        private float _height;

        public PoundsPerSquareInch GetPressure()
        {
            return new PoundsPerSquareInch(13.2f);
        }
        public void WriteMeasurement(TextWriter writer)
        {
            writer.WriteLine(GetPressure().Value);
        }

        public string GetName()
        {
            return "touchprobe";
        }

        public void Move(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public void Pitch(float pitch)
        {
            _pitch = pitch;
        }

        public void Roll(float roll)
        {
            _roll = roll;
        }

        public void Raise(float height)
        {
            _height += height;
        }

        public void Lower(float height)
        {
            _height -= height;
        }
    }

    public struct PoundsPerSquareInch
    {
        public PoundsPerSquareInch(float value)
        {
            Value = value;
        }

        public float Value { get; private set; }
    }
}

using System.Drawing;
using System.IO;
using AbstractionDesignCapabilities.Interfaces;

namespace AbstractionDesignCapabilities.Tools
{
    public class Camera : ISensor, IMovable, IHeightAdjustable, IMeasurable
    {
        private float _zoomLevel;
        private float _x, _y;

        public Image Capture()
        {
            return new Bitmap(100, 100);
        }
        public void WriteMeasurement(TextWriter writer)
        {
            writer.WriteLine(Capture());
        }

        public string GetName()
        {
            return "camera";
        }

        public void Raise(float height)
        {
            _zoomLevel += height;
        }

        public void Lower(float height)
        {
            _zoomLevel -= height;
        }

        public void Move(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
}

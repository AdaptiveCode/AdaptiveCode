using System.Drawing;

namespace AbstractionDesign.Tools
{
    public class Camera : Sensor
    {
        private float _zoomLevel;

        public Camera() : base("camera") { }

        public void Zoom(float level) => _zoomLevel = level;

        public Image Capture()
        {
            return new Bitmap(100, 100);
        }
    }
}

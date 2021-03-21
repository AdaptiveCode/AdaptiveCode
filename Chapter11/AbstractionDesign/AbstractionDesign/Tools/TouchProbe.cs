namespace AbstractionDesign.Tools
{
    public class TouchProbe : Sensor
    {
        private float _pitch, _roll;
        private float _height;

        public TouchProbe() : base("touchprobe") { }

        public void Pitch(float pitch)
        {
            _pitch += pitch;
        }

        public void Roll(float roll)
        {
            _roll += roll;
        }

        public void Raise(float height)
        {
            _height += height;
        }

        public void Lower(float height)
        {
            _height -= height;
        }

        public PoundsPerSquareInch GetPressure()
        {
            return new PoundsPerSquareInch(13.2f);
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

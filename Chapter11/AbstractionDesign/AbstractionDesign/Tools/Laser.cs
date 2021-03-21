namespace AbstractionDesign.Tools
{
    public class Laser : Sensor
    {
        public Laser() : base("laser") { }

        public float Measure()
        {
            return 0f;
        }
    }
}

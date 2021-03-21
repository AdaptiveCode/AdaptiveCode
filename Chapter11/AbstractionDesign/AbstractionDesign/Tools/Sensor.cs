namespace AbstractionDesign.Tools
{
    public abstract class Sensor
    {
        protected readonly string Name;
        protected float X, Y;

        protected Sensor(string name)
        {
            Name = name;
        }

        public virtual void Move(float x, float y)
        {
            X += x;
            Y += y;
        }
    }
}

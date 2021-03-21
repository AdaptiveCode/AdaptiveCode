using System.IO;

namespace AbstractionDesignCapabilities.Interfaces
{
    public interface IMeasurable
    {
        void WriteMeasurement(TextWriter writer);
    }
}

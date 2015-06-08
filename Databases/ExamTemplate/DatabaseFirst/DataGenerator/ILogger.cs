namespace DataGenerator
{
    public interface ILogger
    {
        void Write(string value);

        void WriteLine(string value);

        void WriteLine();
    }
}

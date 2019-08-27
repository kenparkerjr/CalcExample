namespace Calc.Parsing
{
    public interface IHeader
    {
        string HeaderEnd { get; }
        string HeaderStart { get; }

        string[] Parse(string headerString);
        int GetHeaderLength(string s);
    }
}
namespace Calc
{
    public interface IParseOptions
    {
        int? MaximumNumbers { get; }
        bool ShouldDenyNegativeNumbers { get; }
        long UpperBound { get; }
    }
}
using System;

namespace Calc
{
    public class ParseOptions : IParseOptions
    {
        public int? MaximumNumbers { get; private set; }
        public long UpperBound { get; private set; }
        public bool ShouldDenyNegativeNumbers { get; private set; }
        private ParseOptions() { }
        public static IParseOptions Create(int? maximumNumbers = null, long upperBound = 1000, bool shouldDenyNegativeNumbers=true)
        {
            return new ParseOptions()
            {
                MaximumNumbers = maximumNumbers,
                UpperBound = upperBound,
                ShouldDenyNegativeNumbers = shouldDenyNegativeNumbers
            };

        }
        public readonly static IParseOptions Default = ParseOptions.Create();

    }
}

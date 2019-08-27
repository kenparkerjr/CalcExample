namespace Calc
{
    public interface IMath
    {
        long Add(long[] values);
        long Subtract(long[] values);
        long Multiply(long[] values);
        long Divide(long[] values);
        void ValidateNumbers(long[] values);
    }
}
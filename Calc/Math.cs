using Calc.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Calc.Exceptions;

namespace Calc
{
    public class Math : IMath
    {
        private readonly IMathOptions options;
        public IMathOptions Options { get => options; }
        public Math(IMathOptions options)
        {
            this.options = options;
        }
        public Math()
        {
            this.options = new MathOptions();
        }
        public void ValidateNumbers(long[] values)
        {
            if (options.ShouldDenyNegative && values.Min() < 0)
                throw new NegativeNumbersException(values.Where(n => n < 0).ToArray<long>());

            if (!(options.MaximumNumbers is null))
            {
                if (values.Length > options.MaximumNumbers)
                    throw new MaximumNumberExeption(options.MaximumNumbers.Value, values.Length);
            }
        }

        public long AddNumbers(long[] values)
        {
            ValidateNumbers(values);
            long total = 0;
            foreach (long n in values)
            {
                if (n > options.LargestNumber)
                    continue;
                if (options.ShouldDenyNegative && n < 0)
                    continue;
                total += n;
            }

            return total;
        }
    }
}

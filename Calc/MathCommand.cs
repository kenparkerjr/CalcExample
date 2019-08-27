using Calc.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public abstract class MathCommand : IMathCommand
    {
        private readonly IMathOptions options;
        protected abstract long operation(long? total, long n);
        public MathCommand(IMathOptions options)
        {
            this.options = options;
        }
        public long Execute(long[] values)
        {
            long? total =null;
            foreach (long n in values)
            {
                if (n > options.LargestNumber)
                    continue;
                if (options.ShouldDenyNegative && n < 0)
                    continue;
                total = operation(total, n);
            }

            return total.Value;
        }
    }
    public class AddCommand : MathCommand
    {
        public AddCommand(IMathOptions options) : base(options) { }
        protected override long operation(long? total, long n)
        {
            total = total ?? 0;
            return total.Value + n;
        }
    }
    public class SubtractCommand : MathCommand
    {
        public SubtractCommand(IMathOptions options) : base(options) { }
        protected override long operation(long? total, long n)
        {
            if (total is null)
                return n;
            return total.Value - n;
        }
    }
    public class MultiplyCommand : MathCommand
    {
        public MultiplyCommand(IMathOptions options) : base(options) { }
        protected override long operation(long? total, long n)
        {
            if (total is null)
                return n;
            return total.Value * n;
        }
    }
    public class DivideCommand : MathCommand
    {
        public DivideCommand(IMathOptions options) : base(options) { }
        protected override long operation(long? total, long n)
        {
            if (total is null)
                return n;
            return total.Value / n;
        }
    }

}

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
        private readonly IMathCommand addCommand;
        private readonly IMathCommand subtractCommand;
        private readonly IMathCommand multiplyCommand;
        private readonly IMathCommand divideCommand;
        public IMathOptions Options { get => options; }
        public Math(IMathOptions options) : this(options, new AddCommand(options), new SubtractCommand(options), new MultiplyCommand(options), new DivideCommand(options))
        {
            this.options = options;
        }
        public Math(IMathOptions options, IMathCommand addCommand, IMathCommand subtractCommand, IMathCommand multiplyCommand, IMathCommand divideCommand)
        {
            this.options = options;
            this.addCommand = addCommand;
            this.subtractCommand = subtractCommand;
            this.multiplyCommand = multiplyCommand;
            this.divideCommand = divideCommand;
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

        public long Add(long[] values)
        {
            ValidateNumbers(values);
            return addCommand.Execute(values);

        }

        public long Subtract(long[] values)
        {
            ValidateNumbers(values);
            return subtractCommand.Execute(values);
        }

        public long Multiply(long[] values)
        {
            ValidateNumbers(values);
            return multiplyCommand.Execute(values);
        }

        public long Divide(long[] values)
        {
            ValidateNumbers(values);
            return divideCommand.Execute(values);
        }
    }
}

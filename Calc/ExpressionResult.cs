using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class ExpressionResult
    {
        private readonly long[] values;
        private readonly long result;
        

        public ExpressionResult(long result, long[] values)
        {
            this.result = result;
            this.values = values;
        }

        public long[] Values { get => values; }
        public long Result { get => result; }
    }
}

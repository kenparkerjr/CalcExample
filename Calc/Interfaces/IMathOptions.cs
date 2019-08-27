using System;
using System.Collections.Generic;
using System.Text;

namespace Calc.Interfaces
{
    public interface IMathOptions
    {
        bool ShouldDenyNegative { get;  }
        long LargestNumber { get;  }
        int? MaximumNumbers { get; }
    }
}

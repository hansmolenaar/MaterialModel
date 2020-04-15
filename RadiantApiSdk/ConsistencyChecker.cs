using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.RadiantApiSdk
{
   public delegate bool ConsistencyChecker(IReadOnlyList<string> choices, out string errorMessage);
}

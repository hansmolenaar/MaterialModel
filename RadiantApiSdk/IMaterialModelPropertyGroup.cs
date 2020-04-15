using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialModel.RadiantApiSdk
{
   public delegate bool BehaviorsConsistencyChecker(IReadOnlyList<string> choices, out string errorMessage);

   public interface IMaterialModelPropertyGroup
   {


      IEnumerable<IMaterialModelProperty> Properties { get; }
      BehaviorsConsistencyChecker ConistencyChecker { get; }


   }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialModel.RadiantApiSdk
{

   public interface IMaterialModelPropertyGroup
   {


      IEnumerable<IMaterialModelProperty> Properties { get; }
      ConsistencyChecker ConistencyChecker { get; }


   }
}

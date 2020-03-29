using System;
using System.Collections.Generic;
using System.Text;

using MaterialModel.RadiantApiSdk.Property;

namespace MaterialModel.RadiantApiSdk
{
   public interface IMaterialModelProperty
   {
      IPropertySingleValue Property { get; }
      IEnumerable<string> Categories { get; }
   }
}

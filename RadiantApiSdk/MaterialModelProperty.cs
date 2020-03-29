using System;
using System.Collections.Generic;
using System.Linq;

using MaterialModel.RadiantApiSdk.Property;

namespace MaterialModel.RadiantApiSdk
{
   public class MaterialModelProperty : IMaterialModelProperty
   {
      public MaterialModelProperty(IPropertySingleValue prop, params string[] categories)
      {
         Property = prop;
         Categories = categories.ToArray();
      }


      public IPropertySingleValue Property { get; }
      public IEnumerable<string> Categories { get; }
   }
}

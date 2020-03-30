using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using HelloWpf.Plugin.MaterialModelProperties;

namespace MaterialModel.RadiantApiSdk
{
   public class MaterialModelPropertyIDO
   {
      public MaterialModelPropertyIDO(IMaterialModelProperty prop)
      {
         Property = prop;
         Name = prop.Property.Name;
         if ( string.IsNullOrEmpty(Name))
         {
            throw new Exception("MaterialModelPropertyIDO: expect property name");
         }
         Value = 0;
         Unit = prop.Property.Quantity.Unit;
      }

      public string Name { get; }
      public double Value { get; set; }
      public string Unit { get; }

      private IMaterialModelProperty Property { get; }

   }
}

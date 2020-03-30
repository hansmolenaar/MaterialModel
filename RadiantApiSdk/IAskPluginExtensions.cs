using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialModel.RadiantApiSdk
{
   public static class IAskPluginExtensions
   {
      public static bool TryGetMaterialModel(this IAskPlugin askPlugin, string materialString, out IMaterialModel material)
      {
         material = askPlugin.AvailableMaterialModels.Where(m => m.DisplayName == materialString).FirstOrDefault();
         return material != null;
      }
   }
}

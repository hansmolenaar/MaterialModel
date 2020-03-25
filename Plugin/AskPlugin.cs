using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RadiantApiSdk;
using Plugin.MaterialModels;

namespace Plugin
{
   public class AskPlugin : IAskPlugin
   {
      private static IMaterialModel[] m_material = new IMaterialModel[] {
            new MaterialModelMohrCoulomb(),
            new MaterialModelMohrCoulomb(),
         };

      public IEnumerable<IMaterialModel> AvailableMaterialModels { get { return m_material; } }
   }
}

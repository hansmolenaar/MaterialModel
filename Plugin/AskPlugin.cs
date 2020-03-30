using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MaterialModel.RadiantApiSdk;

namespace MaterialModel.Plugin
{
   public class AskPlugin : IAskPlugin
   {
      private static IMaterialModel[] m_material = new IMaterialModel[] {
            new MaterialModelLinearElastic(),
            new MaterialModelMohrCoulomb(),
         };

      public IEnumerable<IMaterialModel> AvailableMaterialModels { get { return m_material; } }
   }
}

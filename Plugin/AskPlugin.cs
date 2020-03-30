using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MaterialModel.RadiantApiSdk;
using MaterialModel.RadiantApiSdk.Property;

namespace MaterialModel.Plugin
{
   public class AskPlugin : IAskPlugin
   {
      private static IMaterialModel[] m_material = new IMaterialModel[] {
            new MaterialModelLinearElastic(),
            new MaterialModelMohrCoulomb(),
         };

      public IEnumerable<IMaterialModel> AvailableMaterialModels { get { return m_material; } }

      public IEnumerable<IMaterialModelProperty> GetGeneralProperties(TopologicalSupport support)
      {
         if ( support == TopologicalSupport.Volume)
         {
            yield return new MaterialModelProperty(PropertySingleValueFactory.CreateDensity());
         }
      }
   }
}

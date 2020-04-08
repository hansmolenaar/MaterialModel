using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MaterialModel.RadiantApiSdk;
using MaterialModel.RadiantApiSdk.Property;

namespace MaterialModel.Plugin
{
   public class MaterialModelCoulombFriction : IMaterialModel
   {
      private IMaterialModelProperty[] m_components = new IMaterialModelProperty[] {
         new MaterialModelProperty(PropertySingleValueFactory.CreateFrictionAngle()),
          new MaterialModelProperty(PropertySingleValueFactory.CreateCohesion()),
      };

      public TopologicalSupport Support { get { return TopologicalSupport.Surface; } }

      public string DisplayName { get { return "Coulomb Friction"; } }
      public IEnumerable<IMaterialModelProperty> Elastic { get { return Enumerable.Empty<IMaterialModelProperty>(); } }
      public IEnumerable<IMaterialModelProperty> Inelastic { get { return m_components; } }

      public bool AreElasticBehaviorsConsistent(IReadOnlyList<string> behaviors, out string errorMessage)
      {
         errorMessage = string.Empty;
         return true;
      }
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MaterialModel.RadiantApiSdk;
using MaterialModel.RadiantApiSdk.Property;

namespace MaterialModel.Plugin
{
   public class MaterialModelMohrCoulomb : IMaterialModel
   {
      private MaterialModelLinearElastic m_elasticModel = new MaterialModelLinearElastic();
      private const string s_yieldSurface = "With Rankine yield surface";
      private const string s_nonAssociated = "Non-associated Flow";
      private IMaterialModelProperty[] m_components = new IMaterialModelProperty[] {
         new MaterialModelProperty(PropertySingleValueFactory.CreateFrictionAngle()),
          new MaterialModelProperty(PropertySingleValueFactory.CreateCohesion()),
         new MaterialModelProperty(PropertySingleValueFactory.CreateTensionCutoff(), s_yieldSurface),
         new MaterialModelProperty(PropertySingleValueFactory.CreateDilationAngle(), s_nonAssociated),
      };

      public TopologicalSupport Support { get { return TopologicalSupport.Volume; } }

      public string DisplayName { get { return "Mohr-Coulomb"; } }
      public IEnumerable<IMaterialModelProperty> Elastic { get { return m_elasticModel.Elastic.Where(mp => !mp.Categories.Contains(MaterialModelLinearElastic.TranseverseIsotropic)); } }
      public IEnumerable<IMaterialModelProperty> Inelastic { get { return m_components; } }

      public bool AreElasticBehaviorsConsistent(IReadOnlyList<string> behaviors, out string errorMessage)
      {
         errorMessage = string.Empty;
         return true;
      }
   }
}

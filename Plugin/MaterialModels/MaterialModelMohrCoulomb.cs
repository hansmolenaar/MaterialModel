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
      private static MaterialModelLinearElastic m_elasticModel = new MaterialModelLinearElastic();
      private const string s_yieldSurface = "With Rankine yield surface";
      private const string s_nonAssociated = "Non-associated Flow";
      private static IMaterialModelProperty[] m_inelasticsProps = new IMaterialModelProperty[] {
         new MaterialModelProperty(PropertySingleValueFactory.CreateFrictionAngle()),
          new MaterialModelProperty(PropertySingleValueFactory.CreateCohesion()),
         new MaterialModelProperty(PropertySingleValueFactory.CreateTensionCutoff(), s_yieldSurface),
         new MaterialModelProperty(PropertySingleValueFactory.CreateDilationAngle(), s_nonAssociated),
      };
      private static IMaterialModelProperty[] m_elasticProps = m_elasticModel.ElasticBehaviors.Properties.
         Where(mp => !mp.Categories.Contains(MaterialModelLinearElastic.TranseverseIsotropic)).ToArray();

      private static MaterialModelPropertyGroup m_elastic = MaterialModelPropertyGroup.Create(m_elasticProps, m_elasticModel.ElasticBehaviors.ConistencyChecker);
      private static MaterialModelPropertyGroup m_inelastic = MaterialModelPropertyGroup.CreateNoCheck(m_inelasticsProps);

      public TopologicalSupport Support { get { return TopologicalSupport.Volume; } }

      public string DisplayName { get { return "Mohr-Coulomb"; } }
      public IMaterialModelPropertyGroup ElasticBehaviors { get { return m_elastic; } }
      public IMaterialModelPropertyGroup InelasticBehaviors { get { return m_inelastic; } }
   }
}

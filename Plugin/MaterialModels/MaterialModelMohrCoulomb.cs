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
      private static readonly MaterialModelLinearElastic m_elasticModel = new MaterialModelLinearElastic();
      private const string s_yieldSurface = "With Rankine yield surface";
      private const string s_nonAssociated = "Non-associated Flow";
      private static readonly IMaterialModelProperty[] m_inelasticsProps = new IMaterialModelProperty[] {
         new MaterialModelProperty(PropertySingleValueFactory.CreateFrictionAngle()),
          new MaterialModelProperty(PropertySingleValueFactory.CreateCohesion()),
         new MaterialModelProperty(PropertySingleValueFactory.CreateTensionCutoff(), s_yieldSurface),
         new MaterialModelProperty(PropertySingleValueFactory.CreateDilationAngle(), s_nonAssociated),
      };
      private static readonly IMaterialModelProperty[] m_elasticProps = m_elasticModel.ElasticBehaviors.Properties.
         Where(mp => !mp.Categories.Contains(MaterialModelLinearElastic.TranseverseIsotropic)).
         Where(mp => !mp.Categories.Contains(MaterialModelLinearElastic.FullyAnisotropic)).ToArray();

      private static readonly MaterialModelPropertyGroup m_elastic = MaterialModelPropertyGroup.Create(m_elasticProps, m_elasticModel.ElasticBehaviors.ConistencyChecker);
      private static readonly MaterialModelPropertyGroup m_inelastic = MaterialModelPropertyGroup.CreateNoCheck(m_inelasticsProps);

      public TopologicalSupport Support { get { return TopologicalSupport.Volume; } }

      public string DisplayName => "Mohr-Coulomb";
      public IMaterialModelPropertyGroup ElasticBehaviors => m_elastic;
      public IMaterialModelPropertyGroup InelasticBehaviors => m_inelastic;
   }
}

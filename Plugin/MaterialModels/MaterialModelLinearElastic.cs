using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MaterialModel.RadiantApiSdk;
using MaterialModel.RadiantApiSdk.Property;

namespace MaterialModel.Plugin
{

   public class MaterialModelLinearElastic : IMaterialModel
   {
      private const string s_youngAndPoisson = "Young+Poisson";
      private const string s_bulkAndShear = "Bulk and Shear Modulus";
      public const string TranseverseIsotropic = "Transverse Isotropic";
      public const string LinearThermalExpansion = "Linear Thermal Expansion";
      private static IMaterialModelProperty[] m_components = new IMaterialModelProperty[] {
         new MaterialModelProperty(PropertySingleValueFactory.CreateYoungModulus(), s_youngAndPoisson),
         new MaterialModelProperty(PropertySingleValueFactory.CreatePoissonRatio(), s_youngAndPoisson),
         new MaterialModelProperty(PropertySingleValueFactory.CreateBulkModulus(), s_bulkAndShear),
         new MaterialModelProperty(PropertySingleValueFactory.CreateShearModulus(), s_bulkAndShear),
         new MaterialModelProperty(PropertySingleValueFactory.CreateShearModulus(), s_bulkAndShear),
         new MaterialModelProperty(PropertySingleValueFactory.CreateShearModulus(), s_bulkAndShear),
         new MaterialModelProperty(PropertySingleValueFactory.CreateWithPostFix(PropertySingleValueFactory.CreateYoungModulus(), " P"), TranseverseIsotropic),
         new MaterialModelProperty(PropertySingleValueFactory.CreateWithPostFix(PropertySingleValueFactory.CreateYoungModulus(), " T"), TranseverseIsotropic),
         new MaterialModelProperty(PropertySingleValueFactory.CreateWithPostFix(PropertySingleValueFactory.CreatePoissonRatio(), " P"), TranseverseIsotropic),
         new MaterialModelProperty(PropertySingleValueFactory.CreateWithPostFix(PropertySingleValueFactory.CreatePoissonRatio(), " PT"), TranseverseIsotropic),
         new MaterialModelProperty(PropertySingleValueFactory.CreateWithPostFix(PropertySingleValueFactory.CreatePoissonRatio(), " TP"), TranseverseIsotropic),
         new MaterialModelProperty(PropertySingleValueFactory.CreateThermalExpansion(), LinearThermalExpansion),
      };

      private static MaterialModelPropertyGroup m_elastic = MaterialModelPropertyGroup.Create(m_components, AreElasticBehaviorsConsistent);
      private static MaterialModelPropertyGroup m_inelastic = MaterialModelPropertyGroup.CreateEmpty();

      public string DisplayName { get { return "Linear Elastic"; } }

      public TopologicalSupport Support { get { return TopologicalSupport.Volume; } }
      public IMaterialModelPropertyGroup ElasticBehaviors { get { return m_elastic; } }
      public IMaterialModelPropertyGroup InelasticBehaviors { get { return m_inelastic; } }

      private static bool AreElasticBehaviorsConsistent(IReadOnlyList<string> behaviors, out string errorMessage)
      {
         errorMessage = string.Empty;
         var baseBehaviors = behaviors.Where(b => b != LinearThermalExpansion).Distinct().ToArray();
         if ( baseBehaviors.Count() != 1)
         {
            errorMessage = "Select one of:";
            foreach( string cat in  m_components.SelectMany(c =>c.Categories).Distinct().Where(cc => cc != LinearThermalExpansion))
            {
               errorMessage = errorMessage + "  '" + cat + "'";
            }
            return false;
         }
         return true;
      }

   }
}

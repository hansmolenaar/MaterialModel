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
      private IMaterialModelProperty[] m_components = new IMaterialModelProperty[] {
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

      public string DisplayName { get { return "Linear Elastic"; } }

      public TopologicalSupport Support { get { return TopologicalSupport.Volume; } }
      public IEnumerable<IMaterialModelProperty> Elastic { get { return m_components; } }
      public IEnumerable<IMaterialModelProperty> Inelastic { get { return Enumerable.Empty<IMaterialModelProperty>(); } }

   }
}

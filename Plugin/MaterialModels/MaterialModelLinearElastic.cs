using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RadiantApiSdk;

namespace Plugin.MaterialModels
{
   public class MaterialModelLinearElastic : IMaterialModel
   {
      private static string[] ElasticModels= new string[]{"Isotropic: Young + Poisson", "Isotropic: bulk + shear", "Transverse isotropic"};
      public string DisplayName { get { return "Linear Elastic"; } }

     public IEnumerable<string> AvailableElasticModels { get { return ElasticModels; } }

   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RadiantApiSdk;

namespace Plugin.MaterialModels
{
   public class MaterialModelMohrCoulomb : IMaterialModel
   {
      private static string[] ElasticModels = new string[] { "Isotropic: Young + Poisson" };
      public string DisplayName { get { return "Mohr-Coulomb"; } }
      public IEnumerable<string> AvailableElasticModels { get { return ElasticModels; } }
   }
}

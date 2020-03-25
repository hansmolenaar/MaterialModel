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
      public string DisplayName { get { return "Mohr-Coulomb"; } }

   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantApiSdk
{
   public interface IAskPlugin
   {
      IEnumerable<IMaterialModel> AvailableMaterialModels { get; }
   }
}

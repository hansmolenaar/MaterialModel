using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialModel.RadiantApiSdk
{
   public interface IAskPlugin
   {
      IEnumerable<IMaterialModel> AvailableMaterialModels { get; }
   }
}

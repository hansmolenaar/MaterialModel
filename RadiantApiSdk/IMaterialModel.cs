using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialModel.RadiantApiSdk
{
   public interface IMaterialModel
   {
      string DisplayName { get; }
      TopologicalSupport Support { get; }
      IMaterialModelPropertyGroup ElasticBehaviors { get; }
      IMaterialModelPropertyGroup InelasticBehaviors { get; }
   }
}

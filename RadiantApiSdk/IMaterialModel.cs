﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantApiSdk
{
  public interface IMaterialModel
   {
      string DisplayName { get; }

      IEnumerable<string> AvailableElasticModels { get; }
      //IEnumerable<IMaterialModelComponent> GeneralProperties { get; }
      //IEnumerable<IMaterialModelComponent> ElasticProperties { get; }
      //IEnumerable<IMaterialModelComponent> InelasticProperties { get; }
      //IEnumerable<IMaterialModelComponent> ThermalProperties { get; }
   }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialModel.RadiantApiSdk
{
   public class Formation : CellCollection, ICellCollection
   {

      public Formation(string name) : base(name, TopologicalSupport.Volume)
      {
      }

   }
}

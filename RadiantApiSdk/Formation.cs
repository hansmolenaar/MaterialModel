using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantApiSdk
{
   public class Formation : ICellCollection
   {
      public string Name { get; }

     public TopologicalSupport Support { get { return TopologicalSupport.Volume; } }

      public Formation(string name)
      {
         Name = name;
      }

   }
}

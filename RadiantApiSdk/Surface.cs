using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialModel.RadiantApiSdk
{
   public class Surface : CellCollection, ICellCollection
   {

      public Surface(string name) : base(name, TopologicalSupport.Surface)
      {
      }

   }
}

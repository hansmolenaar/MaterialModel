using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantApiSdk
{
   public enum TopologicalSupport  {Surface, Volume}
   public interface ICellCollection
   {
      string Name { get; }
      TopologicalSupport Support { get; }
   }
}

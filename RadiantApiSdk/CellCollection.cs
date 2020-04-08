using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.RadiantApiSdk
{
   public class CellCollection : ICellCollection
   {
      public string Name { get; }

      public TopologicalSupport Support { get; }

      public CellCollection(string name, TopologicalSupport support)
      {
         Name = name;
         Support = support;
      }

   }
}

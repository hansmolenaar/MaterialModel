using System;
using System.Collections.Generic;
using System.Text;

using MaterialModel.RadiantApiSdk.Quantity;

namespace MaterialModel.RadiantApiSdk.Property
{
   public interface IProperty
   {
      string Name { get; }

      bool TestIsValidState(out string msg);

      void Clear();

   }
}

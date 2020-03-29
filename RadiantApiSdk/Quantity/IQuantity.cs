using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.RadiantApiSdk.Quantity
{
  public interface IQuantity
   {
      string Name { get; }
      string Unit { get; }
   }
}

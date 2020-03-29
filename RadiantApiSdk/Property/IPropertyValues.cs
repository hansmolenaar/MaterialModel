using System;
using System.Collections.Generic;
using System.Text;

using MaterialModel.RadiantApiSdk.Quantity;

namespace MaterialModel.RadiantApiSdk.Property
{
 public  interface IPropertyValues : IProperty
   {
      IQuantity Quantity { get; }
      bool IsValid(double value, out string errorMessage);
   }
}

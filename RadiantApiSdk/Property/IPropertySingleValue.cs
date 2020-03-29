using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.RadiantApiSdk.Property
{
  public interface IPropertySingleValue : IPropertyValues
   {
      bool TryGetValue(out double value);
      void SetValue(double value);
   }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.RadiantApiSdk.Property
{
   public interface IValueBound
   {
      bool IsValid(double value, out string errorMessage);
   }
}

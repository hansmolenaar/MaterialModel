using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using MaterialModel.RadiantApiSdk.Quantity;

namespace MaterialModel.RadiantApiSdk.Property
{
   internal class SingleValueImpl : IPropertySingleValue
   {
      internal  SingleValueImpl(string name, IQuantity q, params IValueBound[] bounds)
      {
         Name = Name;
         Quantity = q;
         m_valueBounds = bounds.ToArray();
         Clear();
      }

      public string Name { get; private set; }
      public IQuantity Quantity { get; private set; }

      public bool TryGetValue( out double val)
      {
         val = m_value;
         return !double.IsNaN(m_value);
      }

      public void Clear()
      {
         m_value = double.NaN;
      }

      public void SetValue( double val)
      {
         string msg;
         if ( !IsValid(val ,out msg))
         {
            throw new Exception(msg);
         }
         m_value = val;
      }

     public bool TestIsValidState(out string msg)
      {
         double value;
         if ( !TryGetValue(out value))
         {
            msg = "No value has been set";
            return false;
         }
         msg = string.Empty;
         return true;
      }

      public bool IsValid(double value, out string errorMessage)
      {
         errorMessage = string.Empty;
         foreach ( var b in m_valueBounds)
         {
            if (!b.IsValid(value,out errorMessage))
            {
               return false;
            }
         }
         return true;
      }

      private double m_value;
      private IValueBound[] m_valueBounds;
   }


   public static class  PropertySingleValueFactory
   {
   }
}

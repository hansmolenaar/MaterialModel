using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.RadiantApiSdk.Property
{
   public enum ValueBoundType { LT, LE, GE, GT };
   internal class ValueBound : IValueBound
   {
      public ValueBound(double value, ValueBoundType boundType)
      {
         Value = value;
         Type = boundType;
      }

     public bool IsValid(double value, out string errorMessage)
      {
         errorMessage = string.Empty;
         switch (Type)
         {
            case ValueBoundType.GE:
               if (value < Value) errorMessage = "Expect value >= " + Value;
               break;
            case ValueBoundType.GT:
               if (value <= Value) errorMessage = "Expect value > " + Value;
               break;
            case ValueBoundType.LT:
               if (value >= Value) errorMessage = "Expect value < " + Value;
               break;
            case ValueBoundType.LE:
               if (value > Value) errorMessage = "Expect value <= " + Value;
               break;
         }
         return string.IsNullOrEmpty(errorMessage);
      }

      private double Value { get; }
      private ValueBoundType Type { get; }
   }

   public static class ValueBoundFactory
   {
      public static IValueBound Create(double value, ValueBoundType boundType)
      {
         return new ValueBound(value, boundType);
      }
   }
}

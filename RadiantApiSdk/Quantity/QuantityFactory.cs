using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.RadiantApiSdk.Quantity
{
   internal class QuantityImpl : IQuantity
   {
      internal QuantityImpl(string name, string unit)
      {
         Name = name;
         Unit = unit;
      }

      public string Name { get; private set; }
      public string Unit { get; private set; }
   }


   public static class QuantityFactory
   {
      private static IQuantity s_pressure = new QuantityImpl("Pressure", "Pa");
      private static IQuantity s_dimensionless = new QuantityImpl("Dimensionless", "-");
      private static IQuantity s_angle = new QuantityImpl("Angle", "Rad");
      private static IQuantity s_density = new QuantityImpl("Density", "kg/m3");

      public static IQuantity Pressure { get { return s_pressure; } }
      public static IQuantity Dimensionless { get { return s_dimensionless; } }
      public static IQuantity Angle { get { return s_angle; } }
      public static IQuantity Density { get { return s_density; } }
   }
}

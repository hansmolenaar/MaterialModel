using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using MaterialModel.RadiantApiSdk.Quantity;

namespace MaterialModel.RadiantApiSdk.Property
{
   internal class SingleValueImpl : IPropertySingleValue
   {
      internal SingleValueImpl(string name, IQuantity q, params IValueBound[] bounds)
      {
         if ( string.IsNullOrEmpty(name))
         {
            throw new Exception("SingleValueImpl: expect name");
         }
         Name = name;
         Quantity = q;
         m_valueBounds = bounds.ToArray();
         Clear();
      }

      public string Name { get; private set; }
      public IQuantity Quantity { get; private set; }

      public bool TryGetValue(out double val)
      {
         val = m_value;
         return !double.IsNaN(m_value);
      }

      public void Clear()
      {
         m_value = double.NaN;
      }

      public void SetValue(double val)
      {
         string msg;
         if (!IsValid(val, out msg))
         {
            throw new Exception(msg);
         }
         m_value = val;
      }

      public bool TestIsValidState(out string msg)
      {
         double value;
         if (!TryGetValue(out value))
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
         foreach (var b in m_valueBounds)
         {
            if (!b.IsValid(value, out errorMessage))
            {
               return false;
            }
         }
         return true;
      }

      private double m_value;
      private IValueBound[] m_valueBounds;
   }

   internal class SingleValuWrapped : IPropertySingleValue
   {
      public string Name { get; }
      private IPropertySingleValue BaseProp { get; }
      internal SingleValuWrapped(IPropertySingleValue prop, string name)
      {
         if ( string.IsNullOrEmpty(name))
         {
            throw new Exception("SingleValuWrapped: expect property name");
         }
         Name = name;
         BaseProp = prop;
      }


      public IQuantity Quantity { get { return BaseProp.Quantity; } }

      public bool TryGetValue(out double val)
      {
         return BaseProp.TryGetValue(out val);
      }

      public void Clear()
      {
         BaseProp.Clear();
      }

      public void SetValue(double val)
      {
         BaseProp.SetValue(val);
      }

      public bool TestIsValidState(out string msg)
      {
         return BaseProp.TestIsValidState(out msg);
      }

      public bool IsValid(double value, out string errorMessage)
      {
         return BaseProp.IsValid(value, out errorMessage);
      }

   }

   public static class PropertySingleValueFactory
   {
      public static IPropertySingleValue CreateDensity()
      {
         var result = new SingleValueImpl("Rock density", QuantityFactory.Density, ValueBoundFactory.Create(0.0, ValueBoundType.GT));
         return result;
      }

      
      public static IPropertySingleValue CreateYoungModulus()
      {
         var result = new SingleValueImpl("YoundModulus", QuantityFactory.Pressure, ValueBoundFactory.Create(0.0, ValueBoundType.GT));
         return result;
      }

      public static IPropertySingleValue CreatePoissonRatio()
      {
         return new SingleValueImpl("PossonRatio", QuantityFactory.Dimensionless, ValueBoundFactory.Create(0.0, ValueBoundType.GE), ValueBoundFactory.Create(0.5, ValueBoundType.LE));
      }

      public static IPropertySingleValue CreateBulkModulus()
      {
         return new SingleValuWrapped(CreateYoungModulus(), "BulkModulus");
      }

      public static IPropertySingleValue CreateShearModulus()
      {
         return new SingleValuWrapped(CreateYoungModulus(), "ShearModulus");
      }


      public static IPropertySingleValue CreateFrictionAngle()
      {
         return new SingleValueImpl("FrictionAngle", QuantityFactory.Angle, ValueBoundFactory.Create(-Math.PI, ValueBoundType.GE), ValueBoundFactory.Create(Math.PI, ValueBoundType.LE));
      }


      public static IPropertySingleValue CreateDilationAngle()
      {
         return new SingleValuWrapped(CreateFrictionAngle(), "Dilation Angle");
      }

      public static IPropertySingleValue CreateWithPostFix(IPropertySingleValue prop, string postFix)
      {
         return new SingleValuWrapped(prop, prop.Name + postFix);
      }

      public static IPropertySingleValue CreateTensionCutoff()
      {
         return new SingleValueImpl("Tension Cutoff", QuantityFactory.Pressure, ValueBoundFactory.Create(0.0, ValueBoundType.GT));
      }

      public static IPropertySingleValue CreateCohesion()
      {
         return new SingleValueImpl("Cohesion", QuantityFactory.Pressure, ValueBoundFactory.Create(0.0, ValueBoundType.GT));
      }

      public static IPropertySingleValue CreateThermalExpansion()
      {
         return new SingleValueImpl("Linear Thermal Expansion", QuantityFactory.ThermalExpansion, ValueBoundFactory.Create(0.0, ValueBoundType.GT));
      }

   }
}

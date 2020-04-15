using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//using HelloWpf.Plugin.MaterialModelProperties;

namespace MaterialModel.RadiantApiSdk
{
   public class MaterialModelPropertyIDO
   {
      private readonly MessageHandler m_messageHendler;

      public MaterialModelPropertyIDO(IMaterialModelProperty prop, MessageHandler messageHandler)
      {
         m_messageHendler = messageHandler;
         Property = prop;
         Name = prop.Property.Name;
         if (string.IsNullOrEmpty(Name))
         {
            throw new Exception("MaterialModelPropertyIDO: expect property name");
         }
         Value = 0;
         Unit = prop.Property.Quantity.Unit;
      }

      public string Name { get; }

      private double m_value = 0;
      public double Value
      {
         get
         {
            return m_value;
         }
         set
         {
            if (Property.Property.IsValid(value, out string errorMessage))
            {
               m_value = value;
            }
            else
            {
               m_messageHendler.Error( "Unexpected value " + value + " for " + Name);
            }
         }
      }

      public string Unit { get; }

      private IMaterialModelProperty Property { get; }

   }
}

using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.GUI
{
   public static class IControlExtensions
   {


      private static IControl FindControl(this IControl currentControl, Predicate<IControl> accept)
      {
         while (currentControl != null && !accept(currentControl))
         {
            currentControl = currentControl.Previous;
         }
         return currentControl;
      }

      public static bool TryGetMaterialModel(this IControl control, out IMaterialModel materialModel)
      {
         var selectMatMod = (SelectionMaterialModel)control.FindControl(c => c is SelectionMaterialModel);
         if (selectMatMod != null)
         {
            return selectMatMod.MyAskMeAnything.AskPlugin.TryGetMaterialModel(selectMatMod.CurrentSelection, out materialModel);
         }

         materialModel = null;
         return false;
      }

      public static bool TryGetCellCollection(this IControl control, out ICellCollection cellCollection)
      {
         var selectRange = (SelectionRange)control.FindControl(c => c is SelectionRange);
         if (selectRange != null)
         {
            return control.MyAskMeAnything.TryGetCellCollection((selectRange).CurrentSelection, out cellCollection);
         }

         cellCollection = null;
         return false;
      }


   }
}

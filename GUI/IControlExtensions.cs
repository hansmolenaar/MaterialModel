using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.GUI
{
   public static class IControlExtensions
   {

      public static bool TryGetMaterialModel( this IControl control, out IMaterialModel materialModel)
      {
         SelectionMaterialModel selectMatMod = control as SelectionMaterialModel;
         while (control != null && selectMatMod == null)
         {
            control = control.Previous;
            selectMatMod = control as SelectionMaterialModel;
         }

        
         if ( selectMatMod != null)
         {
           return selectMatMod.MyAskMeAnything.AskPlugin.TryGetMaterialModel(selectMatMod.CurrentSelection, out materialModel);
         }
         else
         {
            materialModel = null;
            return false;
         }
         
      }

      public static bool TryGetCellCollection(this IControl control , out ICellCollection cellCollection)
      {
         SelectionRange selectRange = control as SelectionRange;
         while (control != null && selectRange == null)
         {
            control = control.Previous;
            selectRange = control as SelectionRange;
         }


         if (selectRange != null)
         {
            return  control. MyAskMeAnything.TryGetCellCollection((selectRange).CurrentSelection, out cellCollection);
         }
         else
         {
            cellCollection = null;
            return false;
         }

      }

           
   }
}

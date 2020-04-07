using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Linq;

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

      public static bool TryGetCellCollection(this IControl control, out IReadOnlyList<ICellCollection> cellCollection)
      {
         var selectRange = (SelectionRange)control.FindControl(c => c is SelectionRange);
         if (selectRange != null)
         {
            var result = new List<ICellCollection>();
            foreach (var ccName in selectRange.CurrentSelection)
            {
               ICellCollection cc;
               if (control.MyAskMeAnything.TryGetCellCollection(ccName, out cc))
               {
                  result.Add(cc);
               }
            }
            cellCollection = result;
            return cellCollection.Any();
         }

         cellCollection = null;
         return false;
      }

      public static bool TryGetElasticBehaviors(this IControl control, out IReadOnlyList<string> elasticBehaviors)
      {
         var selectElastic = (SelectionElastic)control.FindControl(c => c is SelectionElastic);
         if (selectElastic != null)
         {
            elasticBehaviors = selectElastic.CurrentSelection.ToArray();         
            return elasticBehaviors.Any();
         }

         elasticBehaviors = null;
         return false;
      }

   }
}

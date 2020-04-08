using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialModel.GUI
{
   public static class IControlExtensions
   {

      public static void ClearTail(this IControl selection)
      {
         var nxt = selection.Next;
         while (nxt != null)
         {
            nxt.Clear();
            nxt = nxt.Next;
         }
         if (selection.Next != null)
         {
            selection.Next.Init();
         }
      }

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
            return selectMatMod.MyAskMeAnything.AskPlugin.TryGetMaterialModel(selectMatMod.GetSelection(), out materialModel);
         }

         materialModel = null;
         return false;
      }

      public static IMaterialModel GetMaterialModelSafe(this IControl control)
      {
         IMaterialModel result;
         if ( !control.TryGetMaterialModel(out result))
         {
            throw new Exception("Cannot find material model");
         }
         return result;
      }


      public static bool TryGetCellCollection(this IControl control, out IReadOnlyList<ICellCollection> cellCollection)
      {
         var selectRange = (SelectionRange)control.FindControl(c => c is SelectionRange);
         if (selectRange != null)
         {
            var result = new List<ICellCollection>();
            foreach (var ccName in selectRange.GetSelections())
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

      private static bool TryGetBehaviors(this IControlListBox listBox, out IReadOnlyList<string> behaviors)
      {
         if (listBox != null)
         {
            behaviors = listBox.GetSelections();
            return behaviors.Any();
         }

         behaviors = null;
         return false;
      }

      public static bool TryGetElasticBehaviors(this IControl control, out IReadOnlyList<string> elasticBehaviors)
      {
         var selectElastic = (SelectionElastic)control.FindControl(c => c is SelectionElastic);
         return selectElastic.TryGetBehaviors(out elasticBehaviors);
      }

      public static bool TryGetInelasticBehaviors(this IControl control, out IReadOnlyList<string> inelasticBehaviors)
      {
         var selectInelastic = (SelectionInelastic)control.FindControl(c => c is SelectionInelastic);
         return selectInelastic.TryGetBehaviors(out inelasticBehaviors);
      }

   }
}

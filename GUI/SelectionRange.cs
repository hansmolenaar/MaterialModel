using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using MaterialModel.RadiantApiSdk;

namespace MaterialModel.GUI
{
   public class SelectionRange : ControlListBoxBase, IControlListBox
   {

      public SelectionRange(ListBox listBox, AskMeAnything ame, IControl prev) : base(ame, prev)
      {
         MyListBox = listBox;
         Clear();
      }

      public override void Init()
      {
         // ... Assign the ItemsSource to the List.
         MyListBox.ItemsSource = MyAskMeAnything.Formations.ToArray();
      }

      public override ConsistencyChecker ConsistencyChecker { get { return CheckConsistentSelection; } }

      private bool CheckConsistentSelection(IReadOnlyList<string> choices, out string errorMessage)
      {
         var numSupports = choices.Select(c => MyAskMeAnything.GetCellCollection(c).Support).Distinct().Count();
         if ( numSupports != 1)
         {
            errorMessage = "Select only volumes or surfaces";
            return false;
         }
         errorMessage = string.Empty;
         return true;
      }
   }
}

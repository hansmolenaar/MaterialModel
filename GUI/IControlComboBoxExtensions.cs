using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public static class IControlComboBoxExtensions
   {
      public static string SelectionChanged(this IControlComboBox selection, object sender, SelectionChangedEventArgs e)
      {
         // ... Get the ComboBox.
         var comboBox = (ComboBox)sender;
         selection.CheckComboBox(comboBox);
         selection.ClearTail();
         selection.InitNext();
         return selection.GetSelection();
      }

      public static void CheckComboBox(this IControlComboBox selection, ComboBox cb)
      {
         if (cb != selection.MyComboBox)
         {
            throw new Exception("Unexpected combo box");
         }
      }

      public static string GetSelection(this IControlComboBox selection)
      {
         return selection.MyComboBox.SelectedItem as string;
      }
   }
}

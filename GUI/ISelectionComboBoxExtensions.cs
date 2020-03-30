using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public static class ISelectionComboBoxExtensions
   {
      public static string SelectionChanged(this ISelectionComboBox selection, object sender, SelectionChangedEventArgs e)
      {
         // ... Get the ComboBox.
         var comboBox = (ComboBox)sender;
         selection.CheckComboBox(comboBox);

         // ... Set SelectedItem as Window Title.
         var value = comboBox.SelectedItem as string;
         selection.CurrentSelection = value;
         selection.ClearTail();
         return value;
      }

      public static void CheckComboBox(this ISelectionComboBox selection, ComboBox cb)
      {
         if (cb != selection.MyComboBox)
         {
            throw new Exception("Unexpected combo box");
         }
      }
   }
}

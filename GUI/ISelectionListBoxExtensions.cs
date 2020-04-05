using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public static class ISelectionListBoxExtensions
   {
      public static IEnumerable<string> SelectionChanged(this IControlListBox selection, object sender, SelectionChangedEventArgs e)
      {
         // ... Get the ComboBox.
         var listBox = (ListBox)sender;
         selection.CheckListBox(listBox);

         var values = new List<string>();
         foreach (string val in listBox.SelectedItems)
         {
            values.Add(val);
         }
         selection.CurrentSelection = values;
         selection.ClearTail();
         return values;
      }

      public static void CheckListBox(this IControlListBox selection, ListBox lb)
      {
         if (lb != selection.MyListBox)
         {
            throw new Exception("Unexpected list box");
         }
      }
   }
}

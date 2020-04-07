using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public static class IControlListBoxExtensions
   {
      public static IReadOnlyList<string> SelectionChanged(this IControlListBox selection, object sender, SelectionChangedEventArgs e)
      {
         // ... Get the ComboBox.
         var listBox = (ListBox)sender;
         selection.CheckListBox(listBox);

         // ... Set SelectedItem as Window Title.
         var selectedItems = new List<string>();
         foreach( string str in listBox.SelectedItems)
         {
            selectedItems.Add(str);
         }
         selection.CurrentSelection = selectedItems;
         selection.ClearTail();
         return selectedItems;
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

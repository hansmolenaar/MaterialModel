using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public static class IControlListBoxExtensions
   {
      public static IReadOnlyList<string> SelectionChanged(this IControlListBox selection, object sender, SelectionChangedEventArgs e, MainWindow window)
      {
         // ... Get the ComboBox.
         var listBox = (ListBox)sender;
         selection.CheckListBox(listBox);
         selection.ClearTail();
         var selectedItems = selection.GetSelections();

         if (selectedItems.Any())
         {
            string errorMessage;
            if (!selection.CheckConsistentSelection(out errorMessage))
            {
               selection.Init();
               selection.MyListBox.UnselectAll();

               // Show error message
               window.Title = errorMessage;
               return new string[0];
            }

            // Echo choice
            {
               string msg = "";
               foreach (var val in selectedItems)
               {
                  msg += (val + "  ");
               }
               window.Title = "Selected: " + msg;
            }
         }

         return selectedItems;
      }

      public static void CheckListBox(this IControlListBox selection, ListBox lb)
      {
         if (lb != selection.MyListBox)
         {
            throw new Exception("Unexpected list box");
         }
      }

      public static bool HasAnyOptions(this IControlListBox selection)
      {
         var itSourse = selection.MyListBox.ItemsSource;
         var iter = itSourse.GetEnumerator();
         return iter.MoveNext();
      }

      public static IReadOnlyList<string> GetSelections( this IControlListBox control)
      {
         var selectedItems = new List<string>();
         foreach (string str in control.MyListBox.SelectedItems)
         {
            selectedItems.Add(str);
         }
         return selectedItems;
      }
   }
}

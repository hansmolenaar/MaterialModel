using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionRange : ISelectionComboBox
   {
      public const string RangeDefault = "-- Select Formation--";
      public ComboBox MyComboBox { get; }

      public AskMeAnything MyAskMeAnything { get; }

      public SelectionRange(ComboBox comboBox,AskMeAnything ame, IControl prev)
      {
         MyAskMeAnything = ame;
         MyComboBox = comboBox;
         Previous = prev;
         Clear();
      }

      public void SetNext(IControl nxt)
      {
         Next = nxt;
      }

      public IControl Previous { get; }
      public IControl Next { get; private set; }

      public void Clear()
      {
         MyComboBox.SelectedIndex = 0;
         CurrentSelection = RangeDefault;
      }

      public void Init()
      {
         // ... Assign the ItemsSource to the List.
         MyComboBox.ItemsSource = new string[] { SelectionRange.RangeDefault }.Concat(MyAskMeAnything.Formations);

         // ... Make the first item selected.
         MyComboBox.SelectedIndex = 0;
      }

      public string CurrentSelection { get; set; }
   }
}

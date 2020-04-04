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

      private AskMeAnything m_askMeAnything { get; }

      public SelectionRange(ComboBox comboBox,AskMeAnything ame, IControl prev)
      {
         m_askMeAnything = ame;
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
         MyComboBox.ItemsSource = new string[] { SelectionRange.RangeDefault }.Concat(m_askMeAnything.Formations);

         // ... Make the first item selected.
         MyComboBox.SelectedIndex = 0;
      }

      public string CurrentSelection { get; set; }
   }
}

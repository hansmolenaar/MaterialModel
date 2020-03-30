using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionMaterialModel : ISelection
   {
      public const string MaterialModelDefault = "-- Select Material Model --";
      public ComboBox MyComboBox { get; }

      private AskMeAnything m_askMeAnything { get; }

      public SelectionMaterialModel(ComboBox comboBox, AskMeAnything ame, ISelection prev)
      {
         m_askMeAnything = ame;
         MyComboBox = comboBox;
         Previous = prev;
         Clear();
      }

      public void SetNext(ISelection nxt)
      {
         Next = nxt;
      }

      public ISelection Previous { get; }
      public ISelection Next { get; private set; }

      public void Clear()
      {
         MyComboBox.SelectedIndex = 0;
         CurrentSelection = MaterialModelDefault;
      }

      public void Init()
      {
         // ... Assign the ItemsSource to the List.
         MyComboBox.ItemsSource = new string[] { SelectionMaterialModel.MaterialModelDefault }.Concat(m_askMeAnything.MaterialModels);

         // ... Make the first item selected.
         MyComboBox.SelectedIndex = 0;
      }

      public string CurrentSelection { get;  set; }
   }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionMaterialModel : ISelection
   {
      public const string MaterialModelDefault = "-- Select Material Model --";
      public ComboBox MyComboBox { get; }
      public SelectionMaterialModel(ComboBox comboBox, ISelection prev)
      {
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

      public string CurrentSelection { get;  set; }
   }
}

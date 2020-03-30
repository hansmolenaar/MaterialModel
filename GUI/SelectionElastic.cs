using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionElastic : ISelection
   {
      public const string ElasticModelDefault = "-- Select Elastic Model --";
      public ComboBox MyComboBox { get; }
      public SelectionElastic(ComboBox comboBox, ISelection prev)
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
         CurrentSelection = ElasticModelDefault;
      }

      public string CurrentSelection { get; private set; }
   }
}

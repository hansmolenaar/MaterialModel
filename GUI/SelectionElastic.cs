using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionElastic : ISelectionComboBox
   {
      public const string ElasticModelDefault = "-- Select Elastic Model --";
      public ComboBox MyComboBox { get; }

      private AskMeAnything m_askMeAnything { get; }

      public SelectionElastic(ComboBox comboBox, AskMeAnything ame, IControl prev)
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
         CurrentSelection = ElasticModelDefault;
      }

      public string CurrentSelection { get; set; }

      public void Init()
      {
         var matmod = Previous as SelectionMaterialModel;
         MyComboBox.ItemsSource = new string[] { SelectionElastic.ElasticModelDefault }.Concat(m_askMeAnything.GetAvailableElasticModels(matmod.CurrentSelection));

         // ... Make the first item selected.
         MyComboBox.SelectedIndex = 0;
      }
   }
}

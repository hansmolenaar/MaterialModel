using MaterialModel.ClientFacing;
using MaterialModel.RadiantApiSdk;
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

      public AskMeAnything MyAskMeAnything { get; }

      public SelectionElastic(ComboBox comboBox, AskMeAnything ame, IControl prev)
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
         CurrentSelection = ElasticModelDefault;
      }

      public string CurrentSelection { get; set; }

      public void Init()
      {
         var elasticBehaviors = new List<string>();
         elasticBehaviors.Add(ElasticModelDefault);

         IMaterialModel materialModel;
         if (this.TryGetMaterialModel(out materialModel))
         {
            elasticBehaviors.AddRange(MyAskMeAnything.GetAvailableElasticModels(materialModel.DisplayName));
         }
         MyComboBox.ItemsSource = elasticBehaviors;

         // ... Make the first item selected.
         MyComboBox.SelectedIndex = 0;
      }
   }
}

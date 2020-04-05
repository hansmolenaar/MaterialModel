using MaterialModel.ClientFacing;
using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionElastic :ControlBase, ISelectionComboBox
   {
      public const string ElasticModelDefault = "-- Select Elastic Model --";
      public ComboBox MyComboBox { get; }


      public SelectionElastic(ComboBox comboBox, AskMeAnything ame, IControl prev) : base(ame, prev)
      {
         MyComboBox = comboBox;
         Clear();
      }

      public void SetNext(IControl nxt)
      {
         Next = nxt;
      }


      public override void Clear()
      {
         MyComboBox.SelectedIndex = 0;
         CurrentSelection = ElasticModelDefault;
      }

      public string CurrentSelection { get; set; }

      public override void Init()
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

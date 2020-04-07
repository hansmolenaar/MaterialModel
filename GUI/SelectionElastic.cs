using MaterialModel.ClientFacing;
using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionElastic : ControlListBoxBase, IControlListBox
   {
      public const string ElasticModelDefault = "-- Select Elastic Model --";


      public SelectionElastic(ListBox listBox, AskMeAnything ame, IControl prev) : base(ame, prev)
      {
         MyListBox = listBox;
         Clear();
      }

      public override void Init()
      {
         var elasticBehaviors = new List<string>();
         IMaterialModel materialModel;
         if (this.TryGetMaterialModel(out materialModel))
         {
            elasticBehaviors.AddRange(MyAskMeAnything.GetAvailableElasticModels(materialModel.DisplayName));
         }
         MyListBox.ItemsSource = elasticBehaviors;
      }
   }
}

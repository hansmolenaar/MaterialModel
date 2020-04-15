﻿using MaterialModel.ClientFacing;
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


      public SelectionElastic(ListBox listBox, AskMeAnything ame, IControl prev, MessageHandler messageHandler) : base(ame, prev, messageHandler)
      {
         MyListBox = listBox;
         Clear();
      }

      public override ConsistencyChecker ConsistencyChecker { get { return CheckConsistentSelection; } }

      private bool CheckConsistentSelection(IReadOnlyList<string> choices,  out string errorMessage)
      {
         var materialModel = this.GetMaterialModelSafe();
         return materialModel.ElasticBehaviors.ConistencyChecker(choices, out errorMessage);
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

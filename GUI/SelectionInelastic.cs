using MaterialModel.ClientFacing;
using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionInelastic : ControlListBoxBase, IControlListBox
   {
      public const string NoInelasticModel = "None";

      public SelectionInelastic(ListBox listBox, AskMeAnything ame, IControl prev) : base(ame, prev)
      {
         MyListBox = listBox;
         Clear();
      }


      public override void Init()
      {
         var inelasticBehaviors = new List<string>();
         IMaterialModel materialModel;
         if (this.TryGetMaterialModel(out materialModel))
         {
            inelasticBehaviors.AddRange(materialModel.Inelastic.SelectMany(p => p.Categories).Distinct());
         }
         MyListBox.ItemsSource = inelasticBehaviors;
      }


   }
}

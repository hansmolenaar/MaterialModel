using MaterialModel.ClientFacing;
using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionInelastic : ControlBase, ISelectionComboBox
   {
      public const string InelasticModelDefault = "-- Select Inelastic Components --";
      public const string NoInelasticModel = "None";
      public ComboBox MyComboBox { get; }


      public SelectionInelastic(ComboBox comboBox, AskMeAnything ame, IControl prev) : base(ame, prev)
      {
         MyComboBox = comboBox;
         Clear();
      }

      public override void Clear()
      {
         MyComboBox.SelectedIndex = 0;
         CurrentSelection = InelasticModelDefault;
      }

      public  string CurrentSelection { get; set; }

      public override void Init()
      {
         var choices = new List<string>();
         choices.Add(InelasticModelDefault);
         IMaterialModel materialModel;
        
         if ( this.TryGetMaterialModel(out materialModel))
         {
            choices.AddRange(materialModel.Inelastic.SelectMany(p => p.Categories).Distinct());
            if ( choices.Count == 1)
            {
               choices.Add(NoInelasticModel);
            }
         }
         MyComboBox.ItemsSource = choices;

         // ... Make the first item selected.
         MyComboBox.SelectedIndex = 0;
      }
   }
}

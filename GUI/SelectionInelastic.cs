using MaterialModel.ClientFacing;
using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionInelastic : ISelectionComboBox
   {
      public const string InelasticModelDefault = "-- Select Inelastic Components --";
      public const string NoInelasticModel = "None";
      public ComboBox MyComboBox { get; }

      public AskMeAnything MyAskMeAnything { get; }

      public SelectionInelastic(ComboBox comboBox, AskMeAnything ame, IControl prev)
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
         CurrentSelection = InelasticModelDefault;
      }

      public string CurrentSelection { get; set; }

      public void Init()
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

﻿using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionInelastic : ISelectionComboBox
   {
      public const string InelasticModelDefault = "-- Select Inelastic Components --";
      public ComboBox MyComboBox { get; }

      private AskMeAnything m_askMeAnything { get; }

      public SelectionInelastic(ComboBox comboBox, AskMeAnything ame, ISelection prev)
      {
         m_askMeAnything = ame;
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
         CurrentSelection = InelasticModelDefault;
      }

      public string CurrentSelection { get; set; }

      public void Init()
      {
         var choices = new List<string>();
         choices.Add(InelasticModelDefault);
         var matmodName = ((SelectionMaterialModel)Previous.Previous).CurrentSelection;

         var matSelected = m_askMeAnything.AvailableMaterialModel.Where(m => m.DisplayName == matmodName).ToArray();
         if ( matSelected.Any())
         {
            choices.AddRange(matSelected.Single().Inelastic.SelectMany(p => p.Categories).Distinct());
         }
         MyComboBox.ItemsSource = choices;

         // ... Make the first item selected.
         MyComboBox.SelectedIndex = 0;
      }
   }
}
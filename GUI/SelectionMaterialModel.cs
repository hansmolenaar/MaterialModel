using MaterialModel.ClientFacing;
using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionMaterialModel :ControlBase, IControlComboBox
   {
      public const string MaterialModelDefault = "-- Select Material Model --";
      public ComboBox MyComboBox { get; }

      public SelectionMaterialModel(ComboBox comboBox, AskMeAnything ame, IControl prev, MessageHandler messageHandler) : base(ame, prev, messageHandler)
      {
         MyComboBox = comboBox;
         Clear();
      }

      public override void Clear()
      {
         MyComboBox.SelectedIndex = 0;
         MyComboBox.SelectedItem = MaterialModelDefault;
      }

      public override void Init()
      {
         var items = new List<string>();
         items.Add(MaterialModelDefault);

         IReadOnlyList<ICellCollection> cellCollections;
         if ( this.TryGetCellCollection(out cellCollections))
         {
            if (cellCollections.Any())
            {
               var support = cellCollections.First().Support;
               var matMods = MyAskMeAnything.AvailableMaterialModel.Where(mm => mm.Support == support).Select(mmm => mmm.DisplayName);
               items.AddRange(matMods);
            }
         }

         MyComboBox.ItemsSource = items;

         // ... Make the first item selected.
         MyComboBox.SelectedIndex = 0;
      }

      public string CurrentSelection { get;  set; }
   }
}

using MaterialModel.ClientFacing;
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

      public SelectionMaterialModel(ComboBox comboBox, AskMeAnything ame, IControl prev) : base(ame, prev)
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
         // ... Assign the ItemsSource to the List.
         MyComboBox.ItemsSource = new string[] { SelectionMaterialModel.MaterialModelDefault }.Concat(MyAskMeAnything.MaterialModels);

         // ... Make the first item selected.
         MyComboBox.SelectedIndex = 0;
      }

      public string CurrentSelection { get;  set; }
   }
}

﻿using MaterialModel.ClientFacing;
using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class PropertyPopulation : ControlBase
   {
      public const string ElasticModelDefault = "-- Select Elastic Model --";

      public DataGrid MyDataGrid { get; }

      public PropertyPopulation(DataGrid dataGridProperties, AskMeAnything ame, IControl prev) : base(ame, prev)
      {
         MyDataGrid = dataGridProperties;
         Clear();
      }

      public void SetNext(IControl nxt)
      {
         Next = nxt;
      }


      public override void Clear()
      {
         MyDataGrid.ItemsSource = null;
      }


      public override void Init()
      {
         IMaterialModel materialModel;
         if (this.TryGetMaterialModel(out materialModel))
         {
            var gprops = Enumerable.Empty<IMaterialModelProperty>();
            ICellCollection cellCollection;
            if (this.TryGetCellCollection(out cellCollection))
            {
               gprops = MyAskMeAnything.AskPlugin.GetGeneralProperties(cellCollection.Support);
            }
            var eCategory = (Previous.Previous as SelectionElastic).CurrentSelection;
            var eProps = materialModel.Elastic.Where(p => p.Categories.Contains(eCategory) || !p.Categories.Any()).ToArray();
            var iCategory = (Previous as SelectionInelastic).CurrentSelection;
            var iprops = materialModel.Inelastic.Where(p => p.Categories.Contains(iCategory) || !p.Categories.Any()).ToArray();
            var uniquePropName = new HashSet<string>();
            var props = new List<MaterialModelPropertyIDO>();
            foreach (var p in gprops.Concat(eProps).Concat(iprops))
            {
               if (!uniquePropName.Contains(p.Property.Name))
               {
                  uniquePropName.Add(p.Property.Name);
                  props.Add(new MaterialModelPropertyIDO(p));
               }
            }
            MyDataGrid.ItemsSource = props;
         }
         else
         {
            MyDataGrid.ItemsSource = null;
         }
      }
   }
}

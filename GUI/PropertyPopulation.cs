using MaterialModel.ClientFacing;
using MaterialModel.RadiantApiSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class PropertyPopulation : ControlBase
   {
      public DataGrid MyDataGrid { get; }

      public PropertyPopulation(DataGrid dataGridProperties, AskMeAnything ame, IControl prev) : base(ame, prev)
      {
         MyDataGrid = dataGridProperties;
      }


      public override void Clear()
      {
         MyDataGrid.ItemsSource = null;
      }


      public override void Init()
      {
         Clear();

         IMaterialModel materialModel;
         if (this.TryGetMaterialModel(out materialModel))
         {
            var allProps = new List<IMaterialModelProperty>();
            IReadOnlyList<ICellCollection> cellCollection;
            if (this.TryGetCellCollection(out cellCollection))
            {
               allProps.AddRange(MyAskMeAnything.AskPlugin.GetGeneralProperties(cellCollection.Select(cc => cc.Support).Distinct().Single()));
            }

            IReadOnlyList<string> elasticBehaviors;
            if (this.TryGetElasticBehaviors(out elasticBehaviors))
            {
               allProps.AddRange(materialModel.ElasticBehaviors.Properties.Where(p => p.Categories.Any(pc => elasticBehaviors.Contains(pc)) || !p.Categories.Any()));
            }
            else
            {
               allProps.AddRange(materialModel.ElasticBehaviors.Properties.Where(p => !p.Categories.Any()));
            }

            IReadOnlyList<string> inelasticBehaviors;
            if ( this.TryGetInelasticBehaviors(out inelasticBehaviors))
            {
               allProps.AddRange(materialModel.InelasticBehaviors.Properties.Where(p => p.Categories.Any(pc => inelasticBehaviors.Contains(pc)) || !p.Categories.Any()));
            }
            else
            {
               allProps.AddRange(materialModel.InelasticBehaviors.Properties.Where(p => !p.Categories.Any()));
            }

            var uniquePropName = new HashSet<string>();
            var props = new List<MaterialModelPropertyIDO>();
            foreach (var p in allProps)
            {
               if (!uniquePropName.Contains(p.Property.Name))
               {
                  uniquePropName.Add(p.Property.Name);
                  props.Add(new MaterialModelPropertyIDO(p));
               }
            }
            MyDataGrid.ItemsSource = props;
         }

      }
   }
}

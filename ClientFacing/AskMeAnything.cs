using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MaterialModel.Plugin;
using MaterialModel.RadiantApiSdk;

namespace MaterialModel.ClientFacing
{
   public class AskMeAnything
   {
      public IAskPlugin AskPlugin { get; }

      public AskMeAnything()
      {
         AskPlugin = new AskPlugin();
      }

      public IEnumerable<IMaterialModel> AvailableMaterialModel { get { return AskPlugin.AvailableMaterialModels; } }
      public IEnumerable<string> Formations { get { return AskRadiant.GetCellCollections().Select(cc => cc.Name); } }

      public IEnumerable<string> MaterialModels { get { return AvailableMaterialModel.Select(m => m.DisplayName).Distinct(); } }

      public IEnumerable<string> GetAvailableElasticModels(string materialModel)
      {
         var matmodel = AvailableMaterialModel.Where(m => m.DisplayName == materialModel).SingleOrDefault();
         if (matmodel != null)
         {
            return matmodel.ElasticBehaviors.Properties.SelectMany(c => c.Categories).Distinct();
         }
         else
         {
            return Enumerable.Empty<string>();
         }
      }

      public bool TryGetCellCollection( string name, out ICellCollection cellCollection)
      {
         cellCollection = AskRadiant.GetCellCollections().Where(c => c.Name == name).SingleOrDefault();
         return cellCollection != null;
      }

     
   }
}

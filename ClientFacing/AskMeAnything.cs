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
      private IAskPlugin m_askPlugin = new AskPlugin();

      public AskMeAnything()
      {
      }

      private IEnumerable<IMaterialModel> AvailableMaterialModel { get { return m_askPlugin.AvailableMaterialModels; } }
      public IEnumerable<string> Formations { get { return AskRadiant.GetCellCollections().Select(cc => cc.Name); } }

      public IEnumerable<string> MaterialModels { get { return AvailableMaterialModel.Select(m => m.DisplayName).Distinct(); } }

      public IEnumerable<string> GetAvailableElasticModels(string materialModel)
      {
         var matmodel = AvailableMaterialModel.Where(m => m.DisplayName == materialModel).SingleOrDefault();
         if (matmodel != null)
         {
            return matmodel.Elastic.SelectMany(c => c.Categories).Distinct();
         }
         else
         {
            return Enumerable.Empty<string>();
         }
      }

      //public IEnumerable<string> GetMaterialsInGroup(string materialGroup)
      //{
      //   return AvailableMaterialModel.Where(m => m.MaterialGroup == materialGroup).Select(m => m.MaterialDisplayName);
      //}

      //public IEnumerable<MaterialModelPropertyIDO> GetMaterialModelPropertyIDOs(string materialModel)
      //{
      //   var material = AvailableMaterialModel.Where(m => m.MaterialDisplayName.Equals(materialModel)).FirstOrDefault();
      //   if (material != null)
      //   {
      //      return material.GeneralProperties.Concat(material.ElasticProperties).Concat(material.InelasticProperties).Select(p => new MaterialModelPropertyIDO(p));
      //   }
      //   return Enumerable.Empty<MaterialModelPropertyIDO>();
      //}

      //public MaterialModelIDO GetMaterialModeIDO(string materialModel)
      //{
      //   var material = AvailableMaterialModel.Where(m => m.MaterialDisplayName.Equals(materialModel)).FirstOrDefault();
      //   if ( material != null)
      //   {
      //      return new MaterialModelIDO(material);
      //   }
      //   else
      //   { 
      //      return null; ;
      //   }
      //}
   }
}

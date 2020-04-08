using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialModel.RadiantApiSdk
{
   public static class AskRadiant
   {
      private static ICellCollection[] m_formations = new ICellCollection[]
      {
         new Formation("Broom"),
         new Formation("Rannoch"),
         new Formation("Etive"),
         new Formation("Ness"),
         new Formation("Tarbert"),
         new Surface("Fault"),
      };

      public static IEnumerable<ICellCollection> GetCellCollections()
      {
         return m_formations;
      }
   }
}

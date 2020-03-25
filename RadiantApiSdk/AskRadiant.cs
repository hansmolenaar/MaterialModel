using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiantApiSdk
{
   public static class AskRadiant
   {
      private static Formation[] m_formations = new Formation[]
      {
         new Formation("Broom"),
         new Formation("Rannoch"),
         new Formation("Etive"),
         new Formation("Ness"),
         new Formation("Tarbert")
      };

      public static IEnumerable<ICellCollection> GetCellCollections()
      {
         return m_formations;
      }
   }
}

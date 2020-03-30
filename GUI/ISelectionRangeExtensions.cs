using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.GUI
{
  public static class ISelectionRangeExtensions
   {
      public static void ClearTail(this ISelection selection)
      {
         var nxt = selection.Next;
         while ( nxt != null)
         {
            nxt.Clear();
            nxt = nxt.Next;
         }
         if ( selection.Next != null)
         {
            selection.Next.Init();
         }
      }
   }
}

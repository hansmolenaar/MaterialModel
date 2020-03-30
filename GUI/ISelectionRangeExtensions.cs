using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.GUI
{
  public static class ISelectionRangeExtensions
   {
      public static void ClearTail(this ISelection selection)
      {
         if ( selection.Next != null)
         {
            selection.Next.Clear();
            selection.Next.ClearTail();
         }
      }
   }
}

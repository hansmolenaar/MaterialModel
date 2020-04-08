using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public abstract class ControlListBoxBase : ControlBase, IControlListBox
   {
      public ListBox MyListBox { get; protected set; }

      public override void Clear()
      {
         MyListBox.ItemsSource = new string[0];
      }

      public virtual bool CheckConsistentSelection(out string errorMessage)
      {
         errorMessage = string.Empty;
         return true;
      }

      protected ControlListBoxBase(AskMeAnything ame, IControl prev) : base(ame, prev)
      {
         if (prev != null)
         {
            prev.Next = this;
         }
      }


   }
}

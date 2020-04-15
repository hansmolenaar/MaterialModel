using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using MaterialModel.RadiantApiSdk;

namespace MaterialModel.GUI
{
   public abstract class ControlListBoxBase : ControlBase, IControlListBox
   {
      public ListBox MyListBox { get; protected set; }

      public override void Clear()
      {
         MyListBox.ItemsSource = new string[0];
      }

      public virtual ConsistencyChecker ConsistencyChecker { get { return CheckConsistentSelection; } }

      private bool CheckConsistentSelection(IReadOnlyList<string> choices, out string errorMessage)
      {
         errorMessage = string.Empty;
         return true;
      }

      protected ControlListBoxBase(AskMeAnything ame, IControl prev, MessageHandler messageHandler) : base(ame, prev, messageHandler)
      {
      }


   }
}

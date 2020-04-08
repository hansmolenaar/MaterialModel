using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.GUI
{
   public abstract class ControlBase : IControl
   {
      public AskMeAnything MyAskMeAnything { get; }

      public IControl Previous { get; }

      public IControl Next { get; set; }

      public abstract void Clear();
      public abstract void Init();

      protected ControlBase(AskMeAnything ame, IControl prev)
      {
         MyAskMeAnything = ame;
         Previous = prev;
      }

      public void SetNext(IControl nxt)
      {
         Next = nxt;
      }


   }
}

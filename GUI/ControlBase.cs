using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Text;
using MaterialModel.RadiantApiSdk;

namespace MaterialModel.GUI
{
   public abstract class ControlBase : IControl
   {
      public AskMeAnything MyAskMeAnything { get; }

      public IControl Previous { get; }

      public IControl Next { get; set; }

      public MessageHandler MyMessageHandler { get; }

      public abstract void Clear();
      public abstract void Init();

      protected ControlBase(AskMeAnything ame, IControl prev, MessageHandler messageHandler)
      {
         MyMessageHandler = messageHandler;
         MyAskMeAnything = ame;
         Previous = prev;
         if (prev != null)
         {
            prev.Next = this;
         }
      }


   }
}

using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Text;
using MaterialModel.RadiantApiSdk;

namespace MaterialModel.GUI
{
   public interface IControl
   {
      MessageHandler MyMessageHandler { get; }
      AskMeAnything MyAskMeAnything { get; }
      IControl Previous { get; }
      IControl Next { get; set; }
      void Clear();

      void Init();

   }
}

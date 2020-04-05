using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.GUI
{
   public interface IControl
   {
      AskMeAnything MyAskMeAnything { get; }
      IControl Previous { get; }
      IControl Next { get; }
      void Clear();

      void Init();

   }
}

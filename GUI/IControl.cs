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
      IControl Next { get; set; }
      void Clear();

      void Init();

   }
}

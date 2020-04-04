using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.GUI
{
  public interface IControl
   {
      IControl Previous { get; }
      IControl Next { get; }
      void Clear();

      void Init();

   }
}

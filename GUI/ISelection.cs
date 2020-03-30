using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialModel.GUI
{
  public interface ISelection
   {
      ISelection Previous { get; }
      ISelection Next { get; }
      void Clear();

      void Init();

   }
}

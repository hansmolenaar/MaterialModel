using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using MaterialModel.RadiantApiSdk;

namespace MaterialModel.GUI
{
   public interface IControlListBox : IControl
   {
      ListBox MyListBox { get; }

      // Return succes
      ConsistencyChecker ConsistencyChecker { get; }
   }
}

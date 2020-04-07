using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public interface IControlListBox : IControl
   {
      ListBox MyListBox { get; }
   }
}

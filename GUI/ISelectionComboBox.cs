using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public interface ISelectionComboBox : IControl
   {
      ComboBox MyComboBox { get; }

      string CurrentSelection { get; set; }
   }
}

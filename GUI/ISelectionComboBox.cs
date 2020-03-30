using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public interface ISelectionComboBox : ISelection
   {
      ComboBox MyComboBox { get; }

      string CurrentSelection { get; set; }
   }
}

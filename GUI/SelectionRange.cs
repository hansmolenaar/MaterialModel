﻿using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionRange : ControlListBoxBase, IControlListBox
   {

      public SelectionRange(ListBox listBox, AskMeAnything ame, IControl prev) : base(ame, prev)
      {
         MyListBox = listBox;
         Clear();
      }

      public override void Init()
      {
         // ... Assign the ItemsSource to the List.
         MyListBox.ItemsSource = MyAskMeAnything.Formations.ToArray();
      }
   }
}

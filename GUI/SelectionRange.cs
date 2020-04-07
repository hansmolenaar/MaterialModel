using MaterialModel.ClientFacing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MaterialModel.GUI
{
   public class SelectionRange : ControlListBoxBase, IControlListBox
   {
      public const string RangeDefault = "-- Select Formations--";


      public SelectionRange(ListBox listBox, AskMeAnything ame, IControl prev) : base(ame, prev)
      {
         MyListBox = listBox;
         Clear();
      }

      public void SetNext(IControl nxt)
      {
         Next = nxt;
      }

      public override void Init()
      {
         // ... Assign the ItemsSource to the List.
         MyListBox.ItemsSource = MyAskMeAnything.Formations.ToArray();
      }
   }
}

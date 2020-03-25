using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ClientFacing;
using RadiantApiSdk;

namespace MaterialModel
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private const string FormationDefault = "-- Select Formation--";


      private ComboBox _comboBoxFormations;

      private AskMeAnything m_askMeAnything { get; }

      public MainWindow()
      {
         m_askMeAnything = new AskMeAnything();
         InitializeComponent();
      }

      #region Formations

      private void ComboBoxFormation_Loaded(object sender, RoutedEventArgs e)
      {

         // ... Get the ComboBox reference.
         var comboBox = sender as ComboBox;
         _comboBoxFormations = comboBox;

         // ... Assign the ItemsSource to the List.
         comboBox.ItemsSource = new string[] { FormationDefault }.Concat(m_askMeAnything.Formations);

         // ... Make the first item selected.
         comboBox.SelectedIndex = 0;
      }

      private void ComboBoxFormation_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         // ... Get the ComboBox.
         var comboBox = sender as ComboBox;

         // ... Set SelectedItem as Window Title.
         string value = comboBox.SelectedItem as string;
         this.Title = "Selected: " + value;
      }

      #endregion

   }
}

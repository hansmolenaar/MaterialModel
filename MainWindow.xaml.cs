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
      private const string MaterialModelDefault = "-- Select Material Model --";
      private const string ElasticModelDefault = "-- Select Elastic Model --";

      private ComboBox _comboBoxFormations;
      private ComboBox _comboBoxMaterialModels;
      private ComboBox _comboBoxElasticModels;


      private string _currentMaterialModel = MaterialModelDefault;
      private string _currentElasaticModel = ElasticModelDefault;

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

         // Reset the material groups
         ComboBoxMaterialModel_Reset(_comboBoxMaterialModels);
      }

      #endregion

      #region MaterialModels

      private void ComboBoxMaterialModel_Loaded(object sender, RoutedEventArgs e)
      {

         // ... Get the ComboBox reference.
         var comboBox = sender as ComboBox;
         _comboBoxMaterialModels = comboBox;

         // ... Assign the ItemsSource to the List.
         comboBox.ItemsSource = new string[] { MaterialModelDefault }.Concat(m_askMeAnything.MaterialModels);

         // ... Make the first item selected.
         comboBox.SelectedIndex = 0;
      }

      private void ComboBoxMaterialModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         // ... Get the ComboBox.
         var comboBox = sender as ComboBox;

         // ... Set SelectedItem as Window Title.
         string value = comboBox.SelectedItem as string;
         _currentMaterialModel = value;
         this.Title = "Selected: " + value;

         // Forward selection
         if (_comboBoxElasticModels != null)
         {
            ComboBoxElasticModel_Loaded(_comboBoxElasticModels, null);
         }
      }

      private void ComboBoxMaterialModel_Reset(ComboBox comboBox)
      {
         if (comboBox != null)
         {
            comboBox.SelectedIndex = 0;
            _currentMaterialModel = MaterialModelDefault;
         }
      }

      #endregion

      #region Elastic Models

      private void ComboBoxElasticModel_Loaded(object sender, RoutedEventArgs e)
      {

         // ... Get the ComboBox reference.
         var comboBox = sender as ComboBox;
         _comboBoxElasticModels = comboBox;

         // ... Assign the ItemsSource to the List.
         comboBox.ItemsSource = new string[] { ElasticModelDefault }.Concat(m_askMeAnything.GetAvailableElasticModels(_currentMaterialModel));

         // ... Make the first item selected.
         comboBox.SelectedIndex = 0;
      }

      private void ComboBoxElasticModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         // ... Get the ComboBox.
         var comboBox = sender as ComboBox;

         // ... Set SelectedItem as Window Title.
         string value = comboBox.SelectedItem as string;
         _currentElasaticModel = value;
         this.Title = "Selected: " + value;
      }

      private void ComboBoxElasticModel_Reset(ComboBox comboBox)
      {
         if (comboBox != null)
         {
            comboBox.SelectedIndex = 0;
            _currentElasaticModel = ElasticModelDefault;
         }
      }

      #endregion

   }
}

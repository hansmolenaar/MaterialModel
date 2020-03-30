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

using MaterialModel.ClientFacing;
using MaterialModel.RadiantApiSdk;
using MaterialModel.GUI;
namespace MaterialModel
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private const string FormationDefault = "-- Select Formation--";

      private ComboBox _comboBoxFormations;
      private ComboBox _comboBoxMaterialModels;

      private SelectionElastic m_selectionElasticModel;
      private SelectionMaterialModel m_selectionMaterialModel;

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
         if (m_selectionMaterialModel == null)
         {
            m_selectionMaterialModel = new SelectionMaterialModel(comboBox, null);
         }
         else if (comboBox != m_selectionMaterialModel.MyComboBox)
         {
            throw new Exception("Unexpected combo box");
         }


         // ... Assign the ItemsSource to the List.
         comboBox.ItemsSource = new string[] { SelectionMaterialModel.MaterialModelDefault }.Concat(m_askMeAnything.MaterialModels);

         // ... Make the first item selected.
         comboBox.SelectedIndex = 0;
      }

      private void ComboBoxMaterialModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         // ... Get the ComboBox.
         var comboBox = sender as ComboBox;

         // ... Set SelectedItem as Window Title.
         string value = comboBox.SelectedItem as string;
         m_selectionMaterialModel.CurrentSelection = value;
         this.Title = "Selected: " + value;

         // Forward selection
         if (m_selectionElasticModel != null)
         {
            ComboBoxElasticModel_Loaded(m_selectionElasticModel.MyComboBox, null);
         }
      }

      private void ComboBoxMaterialModel_Reset(ComboBox comboBox)
      {
         if (m_selectionMaterialModel != null)
         {
            m_selectionMaterialModel.Clear();
         }
      }

      #endregion

      #region Elastic Models

      private void ComboBoxElasticModel_Loaded(object sender, RoutedEventArgs e)
      {

         // ... Get the ComboBox reference.
         var comboBox = sender as ComboBox;
         if (m_selectionElasticModel == null)
         {
            m_selectionElasticModel = new SelectionElastic(comboBox, null);
         }
         else if (comboBox != m_selectionElasticModel.MyComboBox)
         {
            throw new Exception("Unexpected combo box");
         }


         // ... Assign the ItemsSource to the List.
         comboBox.ItemsSource = new string[] { SelectionElastic.ElasticModelDefault }.Concat(m_askMeAnything.GetAvailableElasticModels(m_selectionMaterialModel.CurrentSelection));

         // ... Make the first item selected.
         comboBox.SelectedIndex = 0;
      }

      private void ComboBoxElasticModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         // ... Get the ComboBox.
         var comboBox = sender as ComboBox;

         // ... Set SelectedItem as Window Title.
         string value = comboBox.SelectedItem as string;
         m_selectionElasticModel.CurrentSelection = value;
         this.Title = "Selected: " + value;
      }

      private void ComboBoxElasticModel_Reset(ComboBox comboBox)
      {
         if (m_selectionElasticModel != null)
         {
            m_selectionElasticModel.Clear();
         }
      }

      #endregion

   }
}

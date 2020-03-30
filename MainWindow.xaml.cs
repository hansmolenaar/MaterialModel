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

      private ComboBox _comboBoxFormations;


      private SelectionElastic m_selectionElasticModel;
      private SelectionMaterialModel m_selectionMaterialModel;
      private SelectionRange m_selectionRange;

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
         if (m_selectionRange == null)
         {
            m_selectionRange = new SelectionRange(comboBox,m_askMeAnything, null);
         }
         else if (comboBox != m_selectionRange.MyComboBox)
         {
            throw new Exception("Unexpected combo box");
         }

         // ... Assign the ItemsSource to the List.
         comboBox.ItemsSource = new string[] { SelectionRange.RangeDefault }.Concat(m_askMeAnything.Formations);

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

         // Reset rest
         m_selectionRange.ClearTail();
      }

      #endregion

      #region MaterialModels

     
      private void ComboBoxMaterialModel_Loaded(object sender, RoutedEventArgs e)
      {

         // ... Get the ComboBox reference.
         var comboBox = sender as ComboBox;
         if (m_selectionMaterialModel == null)
         {
            m_selectionMaterialModel = new SelectionMaterialModel(comboBox, m_askMeAnything, m_selectionRange);
            m_selectionRange.SetNext(m_selectionMaterialModel);
            m_selectionMaterialModel.Init();
         }
         else if (comboBox != m_selectionMaterialModel.MyComboBox)
         {
            throw new Exception("Unexpected combo box");
         }



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
         m_selectionMaterialModel.ClearTail();
      }

      #endregion

      #region Elastic Models

      private void ComboBoxElasticModel_Loaded(object sender, RoutedEventArgs e)
      {

         // ... Get the ComboBox reference.
         var comboBox = sender as ComboBox;
         if (m_selectionElasticModel == null)
         {
            m_selectionElasticModel = new SelectionElastic(comboBox,m_askMeAnything, m_selectionMaterialModel);
            m_selectionMaterialModel.SetNext(m_selectionElasticModel);
         }
         else if (comboBox != m_selectionElasticModel.MyComboBox)
         {
            throw new Exception("Unexpected combo box");
         }


         // ... Assign the ItemsSource to the List.
         m_selectionElasticModel.Init();
      }

      private void ComboBoxElasticModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         // ... Get the ComboBox.
         var comboBox = sender as ComboBox;

         // ... Set SelectedItem as Window Title.
         string value = comboBox.SelectedItem as string;
         m_selectionElasticModel.CurrentSelection = value;
         this.Title = "Selected: " + value;

         m_selectionElasticModel.ClearTail();
      }

      #endregion

   }
}

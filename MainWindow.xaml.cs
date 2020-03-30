using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
      private SelectionElastic m_selectionElasticModel;
      private SelectionMaterialModel m_selectionMaterialModel;
      private SelectionRange m_selectionRange;
      private SelectionInelastic m_selectionInelastic;

      private DataGrid _dataGridProperties;

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
            m_selectionRange = new SelectionRange(comboBox, m_askMeAnything, null);
            m_selectionRange.Init();
         }
         m_selectionRange.CheckComboBox(comboBox);

      }

      private void ComboBoxFormation_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         string value = m_selectionRange.SelectionChanged(sender, e);
         this.Title = "Selected: " + value;
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
         }

         m_selectionMaterialModel.CheckComboBox(comboBox);
         m_selectionMaterialModel.Init();
      }

      private void ComboBoxMaterialModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         string value = m_selectionMaterialModel.SelectionChanged(sender, e);
         this.Title = "Selected: " + value;
      }

      #endregion

      #region Elastic Models

      private void ComboBoxElasticModel_Loaded(object sender, RoutedEventArgs e)
      {

         // ... Get the ComboBox reference.
         var comboBox = sender as ComboBox;
         if (m_selectionElasticModel == null)
         {
            m_selectionElasticModel = new SelectionElastic(comboBox, m_askMeAnything, m_selectionMaterialModel);
            m_selectionMaterialModel.SetNext(m_selectionElasticModel);
         }
         m_selectionElasticModel.CheckComboBox(comboBox);
         m_selectionElasticModel.Init();
      }

      private void ComboBoxElasticModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         // ... Set SelectedItem as Window Title.
         string value = m_selectionElasticModel.SelectionChanged(sender, e);
         this.Title = "Selected: " + value;
      }

      #endregion

      #region Inelastic Models

      private void ComboBoxInelasticModel_Loaded(object sender, RoutedEventArgs e)
      {

         // ... Get the ComboBox reference.
         var comboBox = sender as ComboBox;
         if (m_selectionInelastic == null)
         {
            m_selectionInelastic = new SelectionInelastic(comboBox, m_askMeAnything, m_selectionElasticModel);
            m_selectionElasticModel.SetNext(m_selectionInelastic);
         }
         m_selectionInelastic.CheckComboBox(comboBox);
         m_selectionInelastic.Init();
      }

      private void ComboBoxInelasticModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         // ... Set SelectedItem as Window Title.
         string value = m_selectionInelastic.SelectionChanged(sender, e);
         this.Title = "Selected: " + value;
         MaterialProperties_Fill();
      }

      #endregion

      #region Material Properties

      private void MaterialProperties_Loaded(object sender, RoutedEventArgs e)
      {
         _dataGridProperties = sender as DataGrid;
         MaterialProperties_Fill();
      }

      private void MaterialProperties_Fill()
      {
         if (_dataGridProperties != null)
         {
            IMaterialModel materialModel;
            if (m_askMeAnything.AskPlugin.TryGetMaterialModel(m_selectionMaterialModel.CurrentSelection, out materialModel))
            {
               var gprops = Enumerable.Empty<IMaterialModelProperty>();
               ICellCollection cellCollection;
               if (m_askMeAnything.TryGetCellCollection(m_selectionRange.CurrentSelection, out cellCollection))
               {
                  gprops = m_askMeAnything.AskPlugin.GetGeneralProperties(cellCollection.Support);
               }
               var eCategory = m_selectionElasticModel.CurrentSelection;
               var eProps = materialModel.Elastic.Where(p => p.Categories.Contains(eCategory) || !p.Categories.Any()).ToArray();
               var iCategory = m_selectionInelastic.CurrentSelection;
               var iprops = materialModel.Inelastic.Where(p => p.Categories.Contains(iCategory) || !p.Categories.Any()).ToArray();
               var uniquePropName = new HashSet<string>();
               var props = new List<MaterialModelPropertyIDO>();
               foreach (var p in gprops.Concat(eProps).Concat(iprops))
               {
                  if (!uniquePropName.Contains(p.Property.Name))
                  {
                     uniquePropName.Add(p.Property.Name);
                     props.Add(new MaterialModelPropertyIDO(p));
                  }
               }
               _dataGridProperties.ItemsSource = props;
            }
            else
            {
               _dataGridProperties.ItemsSource = Enumerable.Empty<MaterialModelPropertyIDO>();
            }
         }
      }
      #endregion

   }
}

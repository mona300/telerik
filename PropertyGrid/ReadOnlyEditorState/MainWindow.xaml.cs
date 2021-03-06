using System;
using System.Linq;
using System.Windows;
using ReadOnlyEditorState;
using Telerik.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ResetPropertyGrid();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            this.propertyGrid.ReadOnlyEditorState = ReadOnlyEditorStates.ReadOnly;
            this.ResetPropertyGrid();
            this.toggleButton.Content = "ReadOnlyEditorState: ReadOnly";
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.propertyGrid.ReadOnlyEditorState = ReadOnlyEditorStates.Disabled;
            this.ResetPropertyGrid();
            this.toggleButton.Content = "ReadOnlyEditorState: Disabled";
        }

        private void ToggleButton_Indeterminate(object sender, RoutedEventArgs e)
        {
            this.propertyGrid.ReadOnlyEditorState = ReadOnlyEditorStates.Default;
            this.ResetPropertyGrid();
            this.toggleButton.Content = "ReadOnlyEditorState: Default";
        }

        private void ResetPropertyGrid()
        {
            this.propertyGrid.Item = null;
            this.propertyGrid.Item = new Employee()
              {
                  FirstName = "Sarah",
                  LastName = "Blake",
                  Occupation = "Supplied Manager",
                  StartingDate = new DateTime(2005, 04, 12),
                  IsMarried = true,
                  Salary = 3500
              };
        }

    }
}

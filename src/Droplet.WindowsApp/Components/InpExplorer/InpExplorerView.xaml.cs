using Droplet.Core.Inp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Droplet.WindowsApp.Components.InpExplorer
{
    /// <summary>
    /// Interaction logic for InpExplorerView.xaml
    /// </summary>
    public partial class InpExplorerView : UserControl
    {
        public InpExplorerView()
        {
            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var context = DataContext as InpExplorerComponent;
            var selectedObject = e.NewValue as IInpEntity;

            if (context is null || selectedObject is null) return;

            context.SelectedObjectId = selectedObject.ID;
        }
    }
}

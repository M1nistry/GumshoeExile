using System;
using System.Windows.Controls;
using Exile.Models;

namespace Exile.Views
{
    public partial class SPLG : UserControl
    {
        private readonly SPLGViewModel _viewmodel;

        public SPLG()
        {
            InitializeComponent();
            _viewmodel = new SPLGViewModel();
            DataContext = _viewmodel;
        }

        private void PartsTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((Part) PartsTabControl.SelectedItem).Id == 0)
            {
                _viewmodel.PartList.Insert(_viewmodel.PartList.Count - 1, new Part
                {
                    Id = _viewmodel.PartList.Count
                });
                Dispatcher.BeginInvoke((Action)(() => PartsTabControl.SelectedIndex = _viewmodel.PartList.Count - 2));
            }
        }
    }
}

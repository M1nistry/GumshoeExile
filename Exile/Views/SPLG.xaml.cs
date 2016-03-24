using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Exile.Models;
using MahApps.Metro.Controls;

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
            ComboMultiAGS.UpdateSource(_viewmodel._persons);
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

        private void ComboBoxWiki_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                int wikiId;
                if (!int.TryParse(ComboBoxWiki.Text, out wikiId)) return;
                _viewmodel.CurrentTicket.WikiIds.Add(wikiId);
                ComboBoxWiki.Text = string.Empty;
            }
        }

        private void ComboMultiAGS_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //We capture the natural reaction of user pressing enter to 'select' the highlighted value, we find the textbox child and set the caret position manually.
            if (e.Text == "\r")
            {
                //TODO We'll need to handle users putting an AGS in here and pressing enter
                var textBox = ComboMultiAGS.ComboBoxGrid.FindChild<TextBox>("PART_EditableTextBox");
                textBox.CaretIndex = textBox.Text.Length;
                e.Handled = false;
                return;
            }
            ComboMultiAGS.ComboBox.IsDropDownOpen = true;
            ComboMultiAGS.FilterText = ComboMultiAGS.ComboBox.Text;
        }

        private void ComboMultiAGS_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter && e.Key != Key.Return) return;
            ComboMultiAGS.FilterText = string.Empty;
            ComboMultiAGS.ComboBox.IsDropDownOpen = false;
        }
    }
}

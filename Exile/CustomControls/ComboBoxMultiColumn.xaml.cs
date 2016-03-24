using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace Exile.CustomControls
{
    /// <summary>
    /// Interaction logic for ComboBoxMultiColumn.xaml
    /// </summary>
    public partial class ComboBoxMultiColumn : UserControl
    {
        private ICollectionView FilterView { get; set; }
        private ObservableCollection<Person> _personCollection { get; set; }
        public ComboBox ComboBox => ComboBoxGrid;

        public string FilterText { get; set; } = string.Empty;
        public object PersonCollection
        {
            get
            {
                if (_personCollection == null)
                {
                    FilterView = CollectionViewSource.GetDefaultView(_personCollection);
                    FilterView.Filter = Filter;
                }
                return _personCollection;
            }
        }


        public ComboBoxMultiColumn()
        {
            InitializeComponent();
        }

        public void UpdateSource(ObservableCollection<Person> Collection)
        {
            if (Collection.GetType() == typeof(ObservableCollection<Person>))
            {
                ComboBoxGrid.ItemContainerStyle = this.Resources["PersonStyle"] as Style;
                ComboBoxGrid.DisplayMemberPath = "Name";
            }
            ComboBoxGrid.DataContext = Collection;
            _personCollection = Collection;
        }

        public bool Filter(object item)
        {
            if (item.GetType() == typeof(Person))
            {
                var person = item as Person;
                return person != null && (person.Name.Contains(FilterText));
            }

            return false;
        }

        private void ComboBoxGrid_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox.Background = (Brush) Resources["AccentColorBrush"];
        }
    }
}

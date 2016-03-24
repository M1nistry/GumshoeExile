using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro;
using MahApps.Metro.Controls;
using Application = System.Windows.Application;
using ComboBox = System.Windows.Controls.ComboBox;
using TabControl = System.Windows.Controls.TabControl;

namespace Exile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly MainWindowViewModel _viewModel;

        private bool Timestamps { get; set; }

        public MainWindow()
        {
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
            InitializeComponent();
            ButtonError.PreviewMouseDown += ButtonError_MouseDown;
            ButtonExpand.PreviewMouseDown += ButtonExpand_MouseDown;
            Timestamps = true;
            AddStatus($"Welcome back, {Environment.UserName}");
        }

        private void AddStatus(string status)
        {
            TextBlockStatus.Text = $"{status}";
            ListBoxStatus.Items.Add($"{(true ? "[" + DateTime.Now.ToShortTimeString() + "] " : string.Empty)} {status}");
        }

        private void ButtonExpand_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //RowStatusStrip.Height = RowStatusStrip.ActualHeight >= 151 ? new GridLength(22) : new GridLength(151);
            //var listBox = ExtendedStatusStripMain.ListBoxStatus;
            //listBox.ScrollIntoView(listBox.Items[listBox.Items.Count-1]);
            
            FlyoutStatus.IsOpen = !FlyoutStatus.IsOpen;
            FlyoutStatus.IsHitTestVisible = FlyoutStatus.IsOpen;
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ListBoxStatus.BorderBrush = (Brush) theme.Item2.Resources["AccentColorBrush"];
            MenuMain.Focus();
        }

        private void ButtonError_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MenuMain.Focus();
        }

        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TabControlMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;
            if (e.Source is TabControl && e.AddedItems[0] is TabControl)
            {
                if (((TabItem) e.AddedItems[0])?.Header?.ToString() == "CLIENTS")
                {
                    //ComboBoxSystem.Foreground = (Brush) FindResource("AccentColorBrush");
                    //this.ShowMessageAsync(, "Hello, world");
                    ///TODO dialog using templates
                    ///http://stackoverflow.com/questions/30751663/how-to-change-mahapps-metro-dialog-content-template-width/30797630#30797630
                }
                else if (((TabItem)e.AddedItems[0]).Header != null && ((TabItem)e.AddedItems[0])?.Header?.ToString() != "CLIENTS")
                {
                    //ComboBoxSystem.Foreground = (Brush)FindResource("AccentColorBrush");
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControlMain.SelectedIndex = 1;
            foreach (var child in FindVisualChildren<ComboBox>(TabControlMain).Where(child => child.Name == "ComboBoxSystem"))
            {
                switch (((ComboBoxItem)child.SelectedValue)?.Content.ToString())
                {
                    case ("SPLG"):
                        TabControlMMG.Visibility = Visibility.Collapsed;
                        TabControlSplg.Visibility = Visibility.Visible;
                        break;

                    case ("MMG"):
                        TabControlSplg.Visibility = Visibility.Collapsed;
                        TabControlMMG.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        private void ComboBoxSystem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TabControlMain.SelectedIndex = 1;
        }

        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield break;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var children = child as T;
                if (children != null)
                {
                    yield return children;
                }

                foreach (var childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }

        private void MenuItemToggle_OnChecked(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Blue"), ThemeManager.GetAppTheme("BaseDark"));
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FlyoutSettings.IsOpen = false;
        }

        private void ComboBoxStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            if (ComboBoxStyle.SelectedItem == ComboBoxItemLight)
            {    
                ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("BaseLight"));
            }
            else
            {
                ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("BaseDark"));
            }
        }

        private void MenuSettings_Click(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            FlyoutSettings.IsModal = true;
            FlyoutSettings.IsOpen = !FlyoutSettings.IsOpen;
            ComboBoxStyle.SelectedItem = theme.Item1.Name.EndsWith("Dark") ? ComboBoxItemDark : ComboBoxItemLight;
        }
    }
}

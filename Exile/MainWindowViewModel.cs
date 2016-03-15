using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Exile
{
    public class MainWindowViewModel
    {
        public List<Part> PartList { get; set; }

        public MainWindowViewModel()
        {
            this.AccentColors = ThemeManager.Accents
                                            .Select(a => new AccentColorMenuData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                            .ToList();
            AccentColors.RemoveAt(AccentColors.Count-1);
            PartList = new List<Part>();
            PartList.Add(new Part
            {
                Id = PartList.Count + 1,
                SpareSerial = "spareSerial",
                SpareMPN = "spareMPN",
                FaultSerial = "faultSerial",
                FaultMPN = "faultMPN"
            });
            PartList.Add(new Part
            {
                Id = PartList.Count + 1,
                SpareSerial = "1",
                SpareMPN = "2",
                FaultSerial = "3",
                FaultMPN = "4"
            });
        }

        public class Part
        {
            public int Id { get; set; }
            public string SpareSerial { get; set; }
            public string SpareMPN { get; set; }
            public string FaultSerial { get; set; }
            public string FaultMPN { get; set; }
        }

        public class AccentColorMenuData
        {
            public string Name { get; set; }
            public Brush BorderColorBrush { get; set; }
            public Brush ColorBrush { get; set; }

            private ICommand changeAccentCommand;

            public ICommand ChangeAccentCommand
            {
                get { return this.changeAccentCommand ?? (changeAccentCommand = new SimpleCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => this.DoChangeTheme(x) }); }
            }

            protected virtual void DoChangeTheme(object sender)
            {
                var theme = ThemeManager.DetectAppStyle(Application.Current);
                var accent = ThemeManager.GetAccent(this.Name);
                ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
                Application.Current.MainWindow.BorderBrush = (System.Windows.Media.Brush)accent.Resources["AccentColorBrush"];
            }
        }

        public class AppThemeMenuData : AccentColorMenuData
        {
            protected override void DoChangeTheme(object sender)
            {
                var theme = ThemeManager.DetectAppStyle(Application.Current);
                var appTheme = ThemeManager.GetAppTheme(this.Name);
                ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
            }
        }


        public List<AccentColorMenuData> AccentColors { get; set; }

        public class SimpleCommand : ICommand
        {
            public Predicate<object> CanExecuteDelegate { get; set; }
            public Action<object> ExecuteDelegate { get; set; }

            public bool CanExecute(object parameter)
            {
                if (CanExecuteDelegate != null)
                    return CanExecuteDelegate(parameter);
                return true;
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public void Execute(object parameter)
            {
                if (ExecuteDelegate != null)
                    ExecuteDelegate(parameter);
            }
        }
    }
}

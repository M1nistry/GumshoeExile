using System;
using System.Windows.Controls;

namespace Exile.CustomControls
{
    /// <summary>
    /// Interaction logic for ExtendedStatusStrip.xaml
    /// </summary>
    public partial class ExtendedStatusStrip : UserControl
    {
        public bool Timestamps { get; set; }

        public ExtendedStatusStrip()
        {
            InitializeComponent();
        }

        public void AddStatus(string status)
        {
            TextBlockStatus.Text = $"{status}";
            ListBoxStatus.Items.Add($"{(Timestamps ? "[" + DateTime.Now.ToShortTimeString() + "] " : string.Empty)} {status}");
        }
        
    }
}

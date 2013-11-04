using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PhotoViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void StartupHandler(object sender, StartupEventArgs e)
        {
            // Elysium.Manager.Apply(this, Elysium.Theme.Light, Elysium.AccentBrushes.Blue, new SolidColorBrush(Colors.Black));
        }
    }
}

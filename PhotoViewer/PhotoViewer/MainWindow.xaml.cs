using System;
using System.Windows.Input;
using MahApps.Metro.Controls;
using PhotoViewer.MessagePayload;
using PhotoViewer.ViewModel;

namespace PhotoViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
            String[] arguments = Environment.GetCommandLineArgs();
            String imagePath = null;
            if (arguments.Length > 1)
            {
                imagePath = arguments[1];
            }
            var mainWindowViewModel = this.DataContext as MainWindowViewModel;
            if (mainWindowViewModel != null)
            {
                mainWindowViewModel.SetImage(imagePath);
            }
            else
            {
                throw new Exception("Great.  You broke it.  I hope you're happy.");
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            String imagePath = null;
            if (e.Key == Key.Left)
            {
                imagePath = DirectoryNavigator.MovePrevious();
            }

            if (e.Key == Key.Right)
            {
                imagePath = DirectoryNavigator.MoveNext();
            }

            var mainWindowViewModel = this.DataContext as MainWindowViewModel;
            if (mainWindowViewModel != null && !String.IsNullOrWhiteSpace(imagePath))
            {
                mainWindowViewModel.SetImage(imagePath);
            }
            e.Handled = true;
        }
    }
}

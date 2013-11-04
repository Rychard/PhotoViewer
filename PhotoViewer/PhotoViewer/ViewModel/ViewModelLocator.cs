/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:PhotoViewer"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PhotoViewer.Controls.ViewModel;

namespace PhotoViewer.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
        }

        public MainWindowViewModel MainWindow
        {
            get
            {
                return new MainWindowViewModel();
            }
        }

        public ExifDataUserControlViewModel ExifData
        {
            get
            {
                return new ExifDataUserControlViewModel();
            }
        }

        public NavigationUserControlViewModel Navigation
        {
            get
            {
                return new NavigationUserControlViewModel();
            }
        }

        public ImageDisplayUserControlViewModel ImageDisplay
        {
            get
            {
                return new ImageDisplayUserControlViewModel();
            }
        }

        public ThumbnailNavigationUserControlViewModel ThumbnailNavigation
        {
            get
            {
                return new ThumbnailNavigationUserControlViewModel();
            }
        }
    }
}
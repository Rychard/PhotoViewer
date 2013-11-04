using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PhotoViewer.Helpers;
using PhotoViewer.MessagePayload;

namespace PhotoViewer.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private String _imageFileName = String.Empty;

        /// <summary>
        /// Sets and gets the ImagePath property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public String ImageFileName
        {
            get { return _imageFileName; }
            set
            {
                if (_imageFileName == value) { return; }
                RaisePropertyChanging("ImageFileName");
                _imageFileName = value;
                RaisePropertyChanged("ImageFileName");
            }
        }

        private String _imagePath = String.Empty;

        /// <summary>
        /// Sets and gets the ImagePath property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public String ImagePath
        {
            get { return _imagePath; }
            set
            {
                if (_imagePath == value) { return; }
                RaisePropertyChanging("ImagePath");
                _imagePath = value;
                RaisePropertyChanged("ImagePath");
            }
        }

        public MainWindowViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }

            MessengerInstance.Register<NavigateDirectionMessage>(this, OnNavigateDirectionMessage);
            MessengerInstance.Register<DisplayImageMessage>(this, OnDisplayImageMessage);
        }

        private void OnDisplayImageMessage(DisplayImageMessage message)
        {
            this.ImagePath = message.ImagePath;
            this.ImageFileName = Path.GetFileName(this.ImagePath);
        }

        private void OnNavigateDirectionMessage(NavigateDirectionMessage obj)
        {
            String imagePath;
            if (obj.Direction == NavigationDirection.Previous)
            {
                imagePath = DirectoryNavigator.MovePrevious(); 
            }
            else if (obj.Direction == NavigationDirection.Next)
            {
                imagePath = DirectoryNavigator.MoveNext(); 
            }
            else
            {
                imagePath = this.ImagePath;
            }
            MessengerInstance.Send(new DisplayImageMessage(imagePath));
        }
    
        public void SetImage(String imagePath = null)
        {
            String path;
            if (!String.IsNullOrWhiteSpace(imagePath))
            {
                path = imagePath;
            }
            else
            {
                if (IsInDesignMode || Debugger.IsAttached)
                {
                    String executableDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                    String relativePath = @"TestImages\wp8start.jpg";
                    if (executableDirectory != null)
                    {
                        String fullPath = Path.Combine(executableDirectory, relativePath);
                        path = fullPath;
                    }
                    else
                    {
                        throw new Exception("The executable is running from a non-existant path?  That can't be right...");
                    }
                }
                else
                {
                    path = imagePath;
                }
            }

            DirectoryNavigator.CurrentImage = path;
            MessengerInstance.Send(new DisplayImageMessage(path));
        }
    }
}

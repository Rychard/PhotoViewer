using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PhotoViewer.MessagePayload;

namespace PhotoViewer.Controls.ViewModel
{
    public class ThumbnailNavigationUserControlViewModel : ViewModelBase
    {
        private String[] _images;

        /// <summary>
        /// Sets and gets the Images property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public String[] Images
        {
            get { return _images; }
            set
            {
                if (_images == value) { return; }
                RaisePropertyChanging("Images");
                _images = value;
                RaisePropertyChanged("Images");
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
                DirectoryNavigator.CurrentImage = value;
                MessengerInstance.Send(new DisplayImageMessage(value));
            }
        }

        public ThumbnailNavigationUserControlViewModel()
        {
            MessengerInstance.Register<DisplayImageMessage>(this, OnDisplayImageMessage);
        }

        private void OnDisplayImageMessage(DisplayImageMessage message)
        {
            this.ImagePath = message.ImagePath;
            this.Images = DirectoryNavigator.Images;
        }
    }
}

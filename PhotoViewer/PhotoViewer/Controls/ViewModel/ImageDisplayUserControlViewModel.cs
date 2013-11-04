using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using PhotoViewer.MessagePayload;

namespace PhotoViewer.Controls.ViewModel
{
    public class ImageDisplayUserControlViewModel : ViewModelBase
    {
        private String _imagePath = String.Empty;
        private Boolean _showActualSize = false;

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

        /// <summary>
        /// Sets and gets the ImagePath property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Boolean ShowActualSize
        {
            get { return _showActualSize; }
            set
            {
                if (_showActualSize == value) { return; }
                RaisePropertyChanging("ShowActualSize");
                _showActualSize = value;
                RaisePropertyChanged("ShowActualSize");
            }
        }



        public ImageDisplayUserControlViewModel()
        {
            MessengerInstance.Register<DisplayImageMessage>(this, OnDisplayImageMessage);
            MessengerInstance.Register<ShowActualSizeMessage>(this, OnShowActualSizeMessage);
        }

        private void OnShowActualSizeMessage(ShowActualSizeMessage message)
        {
            this.ShowActualSize = message.ShowActualSize;
        }

        private void OnDisplayImageMessage(DisplayImageMessage message)
        {
            this.ImagePath = message.ImagePath;
        }
    }
}

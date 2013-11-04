using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PhotoViewer.MessagePayload;

namespace PhotoViewer.Controls.ViewModel
{
    public class ExifDataUserControlViewModel : ViewModelBase 
    {
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

        public ExifDataUserControlViewModel()
        {
            MessengerInstance.Register<DisplayImageMessage>(this, OnDisplayImageMessage);
        }

        private void OnDisplayImageMessage(DisplayImageMessage message)
        {
            this.ImagePath = message.ImagePath;
        }
    }
}

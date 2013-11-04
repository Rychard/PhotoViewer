using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PhotoViewer.Helpers;
using PhotoViewer.MessagePayload;

namespace PhotoViewer.Controls.ViewModel
{
    public class NavigationUserControlViewModel : ViewModelBase
    {
        private Boolean _showActualSize = false;
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


        public RelayCommand NextCommand
        {
            get;
            private set;
        }

        public RelayCommand PreviousCommand
        {
            get;
            private set;
        }

        public NavigationUserControlViewModel()
        {
            MessengerInstance.Register<DisplayImageMessage>(this, OnDisplayImageMessage);
            MessengerInstance.Register<ShowActualSizeMessage>(this, OnShowActualSizeMessage);

            PreviousCommand = new RelayCommand(OnPreviousCommand);
            NextCommand = new RelayCommand(OnNextCommand);

            this.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ShowActualSize")
            {
                MessengerInstance.Send(new ShowActualSizeMessage(this.ShowActualSize));
            }
        }

        private void OnShowActualSizeMessage(ShowActualSizeMessage message)
        {
            this.ShowActualSize = message.ShowActualSize;
        }

        private void OnNextCommand()
        {
            MessengerInstance.Send(new NavigateDirectionMessage(NavigationDirection.Next));
        }

        private void OnPreviousCommand()
        {
            MessengerInstance.Send(new NavigateDirectionMessage(NavigationDirection.Previous));
        }

        private void OnDisplayImageMessage(DisplayImageMessage message)
        {
            ImagePath = message.ImagePath;
        }
    }
}

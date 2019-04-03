using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FulfillmentGo.ViewModels
{
    public class PopupViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string popupTitle = "Popup Title";
        private string popupText = "Popup Text";
        public string PopupTitle
        {
            get { return popupTitle; }
            set
            {
                popupTitle = value;
                RaiseOnPropertyChanged("PopupTitle");
            }
        }

        public string PopupText
        {
            get { return popupText; }
            set
            {
                popupText = value;
                RaiseOnPropertyChanged("PopupText");
            }
        }

        public PopupViewModel()
        {
            
        }

        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

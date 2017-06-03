using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskedUpDownMACTextBox
{
    class MainViewModel : INotifyPropertyChanged
    {
        private string _macLine = "FF-FF-FF-FF-FF-FF";

        public string MACline
        {
            get => _macLine;
            set
            {
                if (_macLine != value)
                {
                    _macLine = Helpers.MACValidator.Validate(value, _macLine);
                    OnPropertyChanged(nameof(MACline));
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);

        }
        #endregion
    }
}

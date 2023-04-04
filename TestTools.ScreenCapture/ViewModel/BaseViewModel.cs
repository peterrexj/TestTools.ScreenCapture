using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTools.ScreenCapture.ViewModel
{
    public class BaseViewModel : BasePropertyChangeModel
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = !value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsFree");
            }
        }
        public bool IsFree => !IsBusy;

        private bool _isActive { get; set; }
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                OnPropertyChanged("IsActive");
            }
        }
    }
}

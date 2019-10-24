using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Droplet.WindowApp
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler == null)
                return;

            if (string.IsNullOrEmpty(propertyName))
                return;

            handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

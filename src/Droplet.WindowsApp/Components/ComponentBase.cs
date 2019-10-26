using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Droplet.WindowsApp.Components
{
    /// <summary>
    /// The base class for all UI Components
    /// </summary>
    public class ComponentBase : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when a property of the component changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The On property changed method that is fired when a property changes
        /// </summary>
        /// <param name="propertyName">The property name that is changing</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

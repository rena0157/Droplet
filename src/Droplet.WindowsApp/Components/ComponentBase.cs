using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Droplet.WindowsApp.Components
{
    /// <summary>
    /// The base class for all UI Components
    /// </summary>
    public class ComponentBase : INotifyPropertyChanged
    {
        protected ComponentBase()
        {
        }

        /// <summary>
        /// Default Constructor that sets the component as the view's 
        /// data context
        /// </summary>
        /// <param name="element">The element for the component</param>
        public ComponentBase(FrameworkElement element)
        {
            element.DataContext = this;
        }

        /// <summary>
        /// The event that is fired when a property of the component changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The Id of this component
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// The On property changed method that is fired when a property changes
        /// </summary>
        /// <param name="propertyName">The property name that is changing</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ComponentBase<T> : ComponentBase where T : FrameworkElement
    {
        public ComponentBase()
        {
        }

        /// <summary>
        /// Default constructor for the component base that hase a view element
        /// </summary>
        /// <param name="view"></param>
        public ComponentBase(T view) : base(view)
        {
            View = view;
        }

        /// <summary>
        /// The view element for this component
        /// </summary>
        public readonly T View;
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Droplet.WindowsApp.Components
{
    /// <summary>
    /// The relay command class
    /// </summary>
    public class RelayCommand<T> : ICommand where T: class
    {

        #region Private Members
        /// <summary>
        /// The command
        /// </summary>
        readonly Action<T> _command; 

        /// <summary>
        /// The predicate for executing the command
        /// </summary>
        readonly Predicate<T> _canExecute;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that will pass an action that will be executed
        /// </summary>
        /// <param name="command">The command that will be executed</param>
        public RelayCommand(Action<T> command) : this(command, p => true)
        {

        }

        /// <summary>
        /// Relay command constructor that passes the command and the predicate that 
        /// tests to see if the command can execute
        /// </summary>
        /// <param name="command">The command that will be executed</param>
        /// <param name="canExecute">Predicate for the command to be executed</param>
        public RelayCommand(Action<T> command, Predicate<T> canExecute)
        {
            _ = command ?? throw new ArgumentNullException(nameof(canExecute));
            _command = command;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Returns true if the command can execute
        /// </summary>
        /// <param name="parameter">The parameter that we are testing</param>
        /// <returns>Returns: true if the command can execute</returns>
        public bool CanExecute(object parameter)
        {
            if (parameter is T p)
                return _canExecute == null ? true : _canExecute(p);
            else 
                return false;
        }

        /// <summary>
        /// Executes the command. Note that the type of the parameter matters and should be checked.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (parameter is T p)
                _command(p);
            else
                throw new ArgumentException(nameof(parameter));
        }

        #endregion

    }
}

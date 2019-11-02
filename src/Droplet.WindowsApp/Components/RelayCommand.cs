using System;
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
        /// The command that will be executed
        /// </summary>
        private readonly Action<T> _command; 

        /// <summary>
        /// The predicate for executing the command
        /// </summary>
        private readonly Predicate<T> _canExecute;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="RelayCommand{T}"/>
        /// </summary>
        /// <param name="command">Delegate to execute when Execute is called on the command</param>
        public RelayCommand(Action<T> command) : this(command, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="RelayCommand{T}"/> with a <see cref="Predicate{T}"/> that 
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
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Returns true if the command can execute
        /// </summary>
        /// <param name="parameter">The parameter that we are testing</param>
        /// <returns>Returns: true if the command can execute</returns>
        public bool CanExecute(object parameter)
            => _canExecute == null ? true : _canExecute((T)parameter);

        /// <summary>
        /// Executes the command. Note that the type of the parameter matters and should be checked.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
            => _command((T)parameter);

        #endregion

    }
}

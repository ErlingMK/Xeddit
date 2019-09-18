using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Xeddit.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///     Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Sets the property.
        /// </summary>
        /// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
        /// <param name="backingStore">Backing store.</param>
        /// <param name="value">Value.</param>
        /// <param name="validateValue">Validates value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <param name="onChanged">On changed.</param>
        /// <param name="commandsToChangeCanExecute">A list of commands to run the <see cref="Command.ChangeCanExecute"/> on</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected virtual bool SetProperty<T>(
            ref T backingStore,
            T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null,
            Func<T, T, bool> validateValue = null,
            params Command[] commandsToChangeCanExecute)
        {
            //if value didn't change
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            //if value changed but didn't validate
            if (validateValue != null && !validateValue(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            commandsToChangeCanExecute?.ForEach(c => c.ChangeCanExecute());
            return true;
        }

        /// <summary>
        ///     Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

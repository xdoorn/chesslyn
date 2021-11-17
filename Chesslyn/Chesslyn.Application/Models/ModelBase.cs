/************************************\
 *                                   *
 *  Chesslyn 2021, Xander van Doorn  *
 *                                   *
\************************************/

// .NET
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Chesslyn.Application.Models
{
  public class ModelBase : INotifyPropertyChanged
  {
    #region Public

    public void OnPropertyChanged([CallerMemberName] string? i_propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(i_propertyName));
    }


    public bool SetProperty(object? i_newValue, bool i_notifySubscribers = true, [CallerMemberName] string? i_propertyName = default)
    {
      if (i_propertyName == null)
      {
        throw new ArgumentNullException(nameof(i_propertyName));
      }

      object? oldValue = GetProperty(i_propertyName);

      bool isValueChanged = IsValueChanged(oldValue, i_newValue);
      if (isValueChanged)
      {
#pragma warning disable CS8601 // Possible null reference assignment.
        m_properties[i_propertyName] = i_newValue;
#pragma warning restore CS8601 // Possible null reference assignment.

        if (i_notifySubscribers)
        {
          OnPropertyChanged(i_propertyName);
        }
      }

      return isValueChanged;
    }


#pragma warning disable CS8601 // Possible null reference assignment.
    public T GetProperty<T>(T i_defaultValue = default, [CallerMemberName] string? i_propertyName = null)
#pragma warning restore CS8601 // Possible null reference assignment.
    {
      T propertyValue = i_defaultValue;

      object? value = GetProperty(i_propertyName);
      if (value != null)
      {
        propertyValue = (T) value;
      }

      return propertyValue;
    }


    public object? GetProperty([CallerMemberName] string? i_propertyName = null)
    {
      object? value = null;

      if (i_propertyName != null)
      {
        m_properties.TryGetValue(i_propertyName, out value);
      }

      return value;
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion

    #region Private

    private bool IsValueChanged(object? i_left, object? i_right)
    {
      bool isChanged = false;

      if (i_left == null)
      {
        isChanged = i_right != null;
      }
      else
      {
        isChanged = !i_left.Equals(i_right);
      }

      return isChanged;
    }


    private readonly Dictionary<string, object> m_properties = new Dictionary<string, object>();

    #endregion
  }
}

/************************************\
 *                                   *
 *  Chesslyn 2021, Xander van Doorn  *
 *                                   *
\************************************/

// .NET
using Chesslyn.Application.Models;
using System;
using System.Windows.Input;


namespace Chesslyn.Application.Commands
{
  public abstract class CommandBase : ModelBase, ICommand
  {
    public string DisplayName
    {
      get => GetProperty<string>();
      set => SetProperty(value);
    }


    public string AltDisplayName
    {
      get => GetProperty<string>();
      set => SetProperty(value);
    }


    #region Abstract ICommand
    public abstract event EventHandler? CanExecuteChanged;
    public abstract bool CanExecute(object? parameter);
    public abstract void Execute(object? parameter);
    #endregion
  }
}

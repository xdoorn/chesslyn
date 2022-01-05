/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System.Windows.Input;

// Prism
using Prism.Commands;

// Chesslyn
using Chesslyn.Application.Models;


namespace Chesslyn.Application.ViewModels
{
  public abstract class ViewModelBase : ModelBase
  {
    public void EvaluateCanExecute(ICommand i_command)
    {
      ((DelegateCommand)i_command).RaiseCanExecuteChanged();
    }
  }
}
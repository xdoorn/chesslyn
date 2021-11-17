/************************************\
 *                                   *
 *  Chesslyn 2021, Xander van Doorn  *
 *                                   *
\************************************/

// .NET
using System;
using System.Windows.Input;


namespace Chesslyn.Application.Commands
{
  internal class ExitCommand : CommandBase
  {
    internal ExitCommand()
    {
      DisplayName = "Exit";
      AltDisplayName = "E_xit";
    }


    public override bool CanExecute(object? parameter)
    {
      return true;
    }


    public override void Execute(object? parameter)
    {
      System.Windows.Application.Current.Shutdown();
    }


    public override event EventHandler? CanExecuteChanged { add { } remove { } }
  }
}

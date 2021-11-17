/************************************\
 *                                   *
 *  Chesslyn 2021, Xander van Doorn  *
 *                                   *
\************************************/

// .NET
using System.Windows.Input;

// Chesslyn
using Chesslyn.Application.Interfaces;


namespace Chesslyn.Application.Commands
{
  public class ApplicationCommands : IApplicationCommands
  {
    public ApplicationCommands()
    {
      Exit = new ExitCommand();
    }


    public ICommand Exit { get; set; }
  }
}

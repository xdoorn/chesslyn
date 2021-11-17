/************************************\
 *                                   *
 *  Chesslyn 2021, Xander van Doorn  *
 *                                   *
\************************************/

// .NET
using System.Windows.Input;


namespace Chesslyn.Application.Interfaces
{
  public interface IApplicationCommands
  {
    ICommand Exit { get; set; }
  }
}

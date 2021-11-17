/************************************\
 *                                   *
 *  Chesslyn 2021, Xander van Doorn  *
 *                                   *
\************************************/

// Chesslyn
using Chesslyn.Application.Interfaces;
using Chesslyn.Application.Models;


namespace Chesslyn.ViewModels
{
  public class ShellViewModel : ModelBase
  {
    public ShellViewModel(IApplicationCommands i_applicationCommands)
    {
      ApplicationCommands = i_applicationCommands;
    }


    public IApplicationCommands ApplicationCommands 
    { 
      get => GetProperty<IApplicationCommands>(); 
      set => SetProperty(value); 
    }
  }
}
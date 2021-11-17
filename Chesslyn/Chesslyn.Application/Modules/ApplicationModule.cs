/************************************\
 *                                   *
 *  Chesslyn 2021, Xander van Doorn  *
 *                                   *
\************************************/

// Prism
using Prism.Ioc;
using Prism.Modularity;

// Chesslyn
using Chesslyn.Application.Commands;
using Chesslyn.Application.Interfaces;


namespace Chesslyn.Application.Modules
{
  public class ApplicationModule : IModule
  {
    public void RegisterTypes(IContainerRegistry i_containerRegistry)
    {
    }


    public void OnInitialized(IContainerProvider i_containerProvider)
    {
    }
  }
}

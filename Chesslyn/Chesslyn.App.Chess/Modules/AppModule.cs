/**************************************\
 *                                     *
 *  Chesslyn © 2021, Xander van Doorn  *
 *                                     *
\**************************************/

// .NET
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Prism
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

// Chesslyn
using Chesslyn.App.Chess.Views;
using Chesslyn.Application.Models;

namespace Chesslyn.App.Chess.Modules
{
  public class AppModule : IModule
  {
    public void RegisterTypes(IContainerRegistry i_containerRegistry)
    {
    }


    public void OnInitialized(IContainerProvider i_containerProvider)
    {
      var regionManager = i_containerProvider.Resolve<IRegionManager>();;
      regionManager.RegisterViewWithRegion(RegionNames.AppsTabRegion, () => i_containerProvider.Resolve<ChessAppView>());
    }
  }
}